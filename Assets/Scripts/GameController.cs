using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Assignment 1                  //
//                       Friday, October 20, 2017                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////

//Controller class for canvas and event handlers
public class GameController : MonoBehaviour {

    //some variables
    [SerializeField]
    public Text Menu;
    [SerializeField]
    public Text Score;
    [SerializeField]
    public Text Health;
    [SerializeField]
    public Text CurrentScore;
    [SerializeField]
    public Text HighScore;
    [SerializeField]
    public Button button;
    [SerializeField]
    public Text buttonText;
    [SerializeField]
    public Button Quit;
    public GameObject[] gamePlayObjects;
    [SerializeField]
    public static GameController Instance;

    //plays the game in its default stage
    //activates and deactivates some canvas as per the need
    private void Initialize()
    {
        //sets score and health to default values
        Player.Instance.Score = 0;
        Player.Instance.Health = 100;
        //gets high score from previous playerprefs save data
        Player.Instance.HighScore = PlayerPrefs.GetInt("highScore");
        HighScore.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        CurrentScore.gameObject.SetActive(false);
        Health.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        button.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
    }


    //this method is invoke when player health is zero and it stops the game
    //activates and deactivates some canvas
    public void GameOver()
    {
        StopGame();
        PlayerPrefs.Save();
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        buttonText.text = "Retry Game";
    }

    //this method is called when the game start and it will not play unless player clicks start button
    public void GameStart()
    {
        StopGame();
        //gets high score from previous save data
        Player.Instance.HighScore = PlayerPrefs.GetInt("highScore");
        HighScore.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(false);
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        buttonText.text = "Start Game";

    }

    //this method is called when the game pause and it will not play unless player clicks resume button
    public void GamePause()
    {
        Time.timeScale = 0;
        PlayerPrefs.Save();
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        buttonText.text = "Resume Game";

    }

    //this method is called when the resume button is click
    public void ClosePause()
    {
        Time.timeScale = 1;
        PlayerPrefs.Save();
        HighScore.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        CurrentScore.gameObject.SetActive(false);
        Health.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
    }

    //this method is invoke when there is change in score, health, highscore and currentscore
    public void UpdateUI()
    {
        Health.text = "Health: " + Player.Instance.Health;
        Score.text = "Score: " + Player.Instance.Score;
        HighScore.text = "High Score: " + Player.Instance.HighScore;
        CurrentScore.text = "Your Score: " + Player.Instance.Score;
    }

    // Use this for initialization
    void Start()
    {
        Player.Instance.gameController = this;
        //sets score and health to default values
        Player.Instance.Score = 0;
        Player.Instance.Health = 100;
        GameStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        //pauses the game
        if (Input.GetKey(KeyCode.Escape))
        {
            //calls gameover method to pause the game
            GamePause();
        }
    }

    //this method starts the game and sets the timescale => 1 regardless of it's current state
    public void RestartButton()
    {
        if(buttonText.text != "Resume Game")
        {
            Initialize();
            Time.timeScale = 1;
        }
        else
        {
            ClosePause();
        }
        
    }

    //this method will close the application
    public void QuitButton()
    {
        PlayerPrefs.Save();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    //this method will stop the gameobjects and sets the timescale => zero
    public void StopGame(bool stop = true)
    {

        gameObject.SetActive(stop);
        foreach (GameObject obj in gamePlayObjects)
        {
            obj.SetActive(!stop);
        }
        Time.timeScale = stop ? 0 : 1;
    }

    
}
