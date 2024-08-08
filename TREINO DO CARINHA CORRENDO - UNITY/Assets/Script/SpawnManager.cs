using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject moeda;
    public int quantMoeda;
    float spawnRange = 3;//Essa vari�vel determina qu�o longe as moedas pode ser instanciadas.
    

    //M�todo que ativa o M�todo SPAWN que � onde est� instanciando. 
    public void Start()
    {
        Spawn();
    }

    //M�todo para instanciar as moedas em lugares aleat�rios na tela do jogo.
    public void Spawn()
    {
         //Aqui est� falando que a quantidade de moedas tem que ser um valor aleat�rio at� 10.
         quantMoeda = Random.Range(0, 10);

        //o iterador [i] inicia em 0, se o iterador [i] for menor que quantMoeda, ent�o o iterador [i] recebe + 1.
        // o [i] rastreia o n�mero atual de itera��es do loop. 
        //Aqui o loop continuar� enquanto o [i] for menor que a quantidade de moedas na cena, e vai acrescentando + 1.
        // Quando o [i] atingir o valor de quantMoedas, o loop para.
        for (int i = 0; i < quantMoeda; i++)
        {
            //Vari�veis para definir valo de X e Y.
            float x = Random.Range(-spawnRange, spawnRange);
            float y = Random.Range(-spawnRange, spawnRange);

            //Vari�vel posi��o que � de um Vector2, tem os valores de X e Y
            Vector2 position = new Vector2(x, y);

            // Instancia a moeda na posi��o gerada
            Instantiate(moeda, position, Quaternion.identity);

        }


    }

    
}
