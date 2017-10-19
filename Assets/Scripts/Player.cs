using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public GameController gameController;

    private int _health = 100;
    private int _score = 0;
    private int _highScore;
    private int _hasPlayed;

    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            gameController.updateUI();
            if(_score > _highScore)
            {
                _highScore = _score;
                PlayerPrefs.SetInt("highScore", _highScore);
                gameController.updateUI();
            }
        }
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                PlayerPrefs.Save();
                gameController.updateUI();
                gameController.gameOver();
            }
            else
            {
                gameController.updateUI();
            }
        }
    }

    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            if (_score > _highScore)
            {
                _highScore = _score;
                gameController.updateUI();
            }
            PlayerPrefs.SetInt("highScore", _highScore);
            gameController.updateUI();
        }
    }
}
