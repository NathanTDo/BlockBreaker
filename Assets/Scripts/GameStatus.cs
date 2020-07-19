using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Start()
    {
        DisplayScore();
    }

    // state variables
    [SerializeField] int currentScore = 0;


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        DisplayScore();
        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void DisplayScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
