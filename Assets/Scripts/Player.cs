using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Assignment 1                  //
//                       Friday, October 20, 2016                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

//Player script for storing score, health and high score
public class Player
{
    //declaring gamecontroller object
    public GameController gameController;

    //private variables
    private int _health = 100;
    private int _score = 0;
    private int _highScore;
    private int _hasPlayed;

    //class object
    private static Player _instance;

    //class copy representing an object of Player class
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

    //accessor and mutator for calculating score
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

    //accessor and mutator for calculating health
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
                //saving highscore before player dies
                PlayerPrefs.Save();
                //calls update method and updates the health in canvas
                gameController.updateUI();
                //calls gameover method
                gameController.gameOver();
            }
            else
            {
                //calls update method and updates the score in canvas
                gameController.updateUI();
            }
        }
    }

    //accessor and mutator for calculating highscore
    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            //if current score is greater than previous high score, then sets high score to current score
            if (_score > _highScore)
            {
                _highScore = _score;
                gameController.updateUI();
            }
            //sets highscore
            PlayerPrefs.SetInt("highScore", _highScore);
            gameController.updateUI();
        }
    }
}
