using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    Text Health;
    [SerializeField]
    Text Score;
    [SerializeField]
    Text Menu;
    [SerializeField]
    Text CurrentScore;
    [SerializeField]
    Text HighScore;
    [SerializeField]
    Button button;
    [SerializeField]
    Text buttonText;

    private static int highScore;
    private static int currentScore;
    public bool gamePaused;
    private static bool gameOver;
    private Player player;
    [SerializeField]
    public GameObject[] sceneGameObjects;
    public static GameController Instance;

    public static int HighScoreValue
    {

        get { return highScore; }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                PlayerPrefs.SetInt("highScore", highScore);
            }
        }
    }

    public static int CurrentScoreValue
    {

        get { return currentScore; }
        set
        {
            currentScore = value;
            if (currentScore > highScore)
            {
                HighScoreValue = currentScore;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        Player.Instance.gameCtrl = this;
        GameStart();
        HighScore.text = "High Score: " + HighScoreValue.ToString();
        gamePaused = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && buttonText.text != "Start" && buttonText.text != "GameOver")
        {
            GamePause();
            PlayerPrefs.SetInt(HighScore.text, highScore);
            gamePaused = true;
            StopGame(false);
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        gamePaused = false;
        HighScoreValue = PlayerPrefs.GetInt("HighScore");
        sceneGameObjects = new GameObject[]
        {
            GameObject.Find("GamePlay")
        };
    }

    public void GameStart()
    {
        Player.Instance.Score = 0;
        Player.Instance.Health = 100;

        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        buttonText.text = "Start";
    }

    public void GamePause()
    {
        Health.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        buttonText.text = "Resume";
    }

    public void GameOver()
    {
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        buttonText.text = "GameOver";
    }

    public void StopGame(bool stop = true)
    {
        gameObject.SetActive(stop);
        foreach (GameObject gObject in sceneGameObjects)
        {
            gObject.SetActive(!stop);
        }
        Time.timeScale = stop ? 0 : 1;
    }

    public void UpdateUI()
    {
        Health.text = "Health: " + Player.Instance.Health;
        Score.text = "Score: " + Player.Instance.Score;
    }

    public void ButtonClick()
    {
        if(buttonText.text == "Start")
        {
            gamePaused = !gamePaused;
            StopGame(false);
        }
        else if(buttonText.text == "Pause")
        {

        }
        else if(buttonText.text == "GameOver")
        {

        }
    }

    
}
