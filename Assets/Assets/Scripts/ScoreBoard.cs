using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class ScoreBoard : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;

    private int _score = 0;

    private void OnEnable()
    {
        Enemy.OnScoreIncrese += IncreaseScore;
    }

    private void Start()
    {
        UpdateScore(_score);
    }

    private void OnDisable()
    {
        Enemy.OnScoreIncrese -= IncreaseScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncreaseScore(int ammountToIncrease)
    {
        _score += ammountToIncrease;
        UpdateScore(_score);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = "SCORE: " + score;
    }
}
