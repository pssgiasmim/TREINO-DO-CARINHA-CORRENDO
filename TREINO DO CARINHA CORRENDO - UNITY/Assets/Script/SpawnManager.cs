using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject moeda;
    float timer, initialTime = 1.2f;
    int quantMoeda;

    public void Spawn()
    {
        
            quantMoeda = Random.Range(0, 10);

            Instantiate(moeda, new Vector3(Random.Range(-GameManager.instance.ScreenBounds.x, GameManager.instance.ScreenBounds.x), GameManager.instance.ScreenBounds.y, 0), Quaternion.identity);
       
    }

    public void Start()
    {
        Spawn();
    }
}
