using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public GameController gameController;

    private int _health = 100;
    private int _score = 0;

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
                gameController.gameOver();
            }
            else
            {
                gameController.updateUI();
            }
        }
    }

    

}
