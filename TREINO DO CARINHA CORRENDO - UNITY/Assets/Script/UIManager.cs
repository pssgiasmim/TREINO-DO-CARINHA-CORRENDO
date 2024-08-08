using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TextMeshProUGUI scoreText;

    public void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = GameManager.instance.Score.ToString();
    }

}
