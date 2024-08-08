using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject moeda;
    public int quantMoeda;
    float spawnRange = 3;//Essa variável determina quão longe as moedas pode ser instanciadas.
    

    //Método que ativa o Método SPAWN que é onde está instanciando. 
    public void Start()
    {
        Spawn();
    }

    //Método para instanciar as moedas em lugares aleatórios na tela do jogo.
    public void Spawn()
    {
         //Aqui está falando que a quantidade de moedas tem que ser um valor aleatório até 10.
         quantMoeda = Random.Range(0, 10);

        //o iterador [i] inicia em 0, se o iterador [i] for menor que quantMoeda, então o iterador [i] recebe + 1.
        // o [i] rastreia o número atual de iterações do loop. 
        //Aqui o loop continuará enquanto o [i] for menor que a quantidade de moedas na cena, e vai acrescentando + 1.
        // Quando o [i] atingir o valor de quantMoedas, o loop para.
        for (int i = 0; i < quantMoeda; i++)
        {
            //Variáveis para definir valo de X e Y.
            float x = Random.Range(-spawnRange, spawnRange);
            float y = Random.Range(-spawnRange, spawnRange);

            //Variável posição que é de um Vector2, tem os valores de X e Y
            Vector2 position = new Vector2(x, y);

            // Instancia a moeda na posição gerada
            Instantiate(moeda, position, Quaternion.identity);

        }


    }

    
}
