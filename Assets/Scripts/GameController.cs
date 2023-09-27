using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] TMP_Text _scoreCounter, _gameOverScore;
    [SerializeField] private Canvas _canvas;

    private int _score, _bestScore;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Best Score"))
        {
            _bestScore = 0;
            PlayerPrefs.SetInt("Best Score", _bestScore);
        }
    }

    public void AddScore()
    {
        _score++;
        PlayerPrefs.SetInt("Score", _score);
        _scoreCounter.text = _score.ToString();
    }

    public void GameOver()
    {
        if (_score > _bestScore)
            PlayerPrefs.SetInt("Best Score", _score);

        _canvas.sortingOrder = 3;
        _gameOverScreen.SetActive(true);
        _gameOverScore.text = _score.ToString();
    }
   
}
