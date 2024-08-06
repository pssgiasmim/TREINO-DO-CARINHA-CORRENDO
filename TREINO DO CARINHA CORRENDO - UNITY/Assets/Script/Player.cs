using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidbody2D;
    float direction, speed = 10

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
    }

}
