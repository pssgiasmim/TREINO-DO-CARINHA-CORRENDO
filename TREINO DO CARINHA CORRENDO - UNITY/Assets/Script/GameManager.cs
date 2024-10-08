using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; //Faz com que o script GameManager possa ser acessado em outro script.
    Vector2 screenBounds;
    int score;

    public Vector2 ScreenBounds { get => screenBounds; }
    public int Score { get => score; set => score = value; }

    private void Awake()
    {
        instance = this;
        screenBounds = new Vector3(-1, 1) + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

    }

}

