using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
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

    private void initialize()
    {
        
        Player.Instance.Score = 0;
        Player.Instance.Health = 100;
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



    public void gameOver()
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
        Menu.text = Menu.text + "\nGame Over";
        buttonText.text = "Retry";
    }

    public void gameStart()
    {
        StopGame();
        Player.Instance.HighScore = PlayerPrefs.GetInt("highScore");
        PlayerPrefs.SetInt("hasPlayed", 0);
        HighScore.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(false);
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        buttonText.text = "Start";

    }

    public void updateUI()
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
        gameStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameOver();
            buttonText.text = "Resume";
        }
    }

    public void RestartButton()
    {
        initialize();
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        PlayerPrefs.Save();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

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
