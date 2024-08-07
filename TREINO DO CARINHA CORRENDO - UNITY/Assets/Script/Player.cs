using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
  

    [SerializeField] Rigidbody2D rigidbody2D;
    float direction, speed = 10;

    bool jumping, onGround;
    [SerializeField] LayerMask groundMask;

    //M�todo que faz o carinha se mover e impede que o player saia dos limites da tela.
    public void Move()
    {
        //Linha que faz o personagem se mover para os lados.
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);

        //Trecho que impede que o player (o carinha) saia dos limites da tela.
        if (transform.position.x < GameManager.instance.ScreenBounds.x * -1)
        {
            transform.position = new Vector2(GameManager.instance.ScreenBounds.x * -1, transform.position.y);
        }
        else
        {
            if (transform.position.x > GameManager.instance.ScreenBounds.x)
            {
                transform.position = new Vector2(GameManager.instance.ScreenBounds.x, transform.position.y);
            }
        }

    }

    //M�todo que "ativa" a linha que faz o personagem se mover para os lados.
    public void Update()
    {
        direction = Input.GetAxis("Horizontal");

        Move();

        //Nesta parte verificamos que o jogador pulou.
        //Checar se a tecla foi para baixo

        CheckGround();

       

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
            jumping = true; 

        }

        //Checar se a tecla foi para cima
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumping = false; //Verifica��o se os dois m�todos de pulo funcionaram.
        }

    }

    private void Jump() //Identifica o pulo(normal) do jogador.
    {
        if  (onGround)
        {
            rigidbody2D.velocity = new Vector2(0, 8);
        }
        
    }

    private void CheckGround() 
    {

        Vector2 offset = new Vector2(0, -0.5f); //Atribuindo o X = 0 e Y = 0.5f para Vector2 offset [que � uma vari�vel].

        Vector2 checkPosition = (Vector2)transform.position + offset; //fazendo transform.position [position � um Vector3 e est� sendo convertido para Vector2] + offset, essa conta est� sendo colocada dentro da vari�vel checckPosition.

        onGround = Physics2D.OverlapCircle(checkPosition, 0.2f, groundMask); // Cria um circulo (OverLapCircle), que tem o raio de 0.2f, e verifica se est� em contato com a Layer groundMask.

        
    }

    //M�todo para quando o Player colidir com a moeda, aumentar o score e a moeda sumir da cena.
    public void OnTriggerEnter2D(Collider2D collision)//Neste caso, o "collision" � a moeda
    {
        if (collision.CompareTag("Player") == true)
        {
            //Acrescentando Score de instance de GameManager + o value, ao, Score.instance.GameManager
             GameManager.instance.Score = GameManager.instance.Score + 10;

            //M�todo do UIManager para atualizar o texto de Score.
             UIManager.instance.UpdateScoreText();

            //M�todo para destruir o "collision" que � a moeda
            Destroy(collision.gameObject);
        }
    }







}
