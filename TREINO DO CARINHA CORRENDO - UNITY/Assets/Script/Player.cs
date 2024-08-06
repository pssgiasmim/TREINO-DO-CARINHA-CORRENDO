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

    //Método que faz o carinha se mover e impede que o player saia dos limites da tela.
    public void Move()
    {
        //Linha que faz o personagem se mover para os lados.
        rigidbody2D.velocity = new Vector2(direction * speed, 0);

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

    //Método que "ativa" a linha que faz o personagem se mover para os lados.
    public void Update()
    {
        direction = Input.GetAxis("Horizontal");

        Move();

        //Nesta parte verificamos que o jogador pulou.
        //Checar se a tecla foi para baixo

        CheckGround();

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            jumping = true; 

        }

        //Checar se a tecla foi para cima
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false; //Verificação se os dois métodos de pulo funcionaram.
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
        onGround = Physics2D.OverlapCircle(transform.position, 0.2f, groundMask); // Cria um circulo (OverLapCircle), que tem o raio de 0.2f, e verifica se está em contato com a Layer groundMask.
    }

   

  

    



}
