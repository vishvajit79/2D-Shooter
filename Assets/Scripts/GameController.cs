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
    public GameObject[] gamePlayObjects;

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
    }

    public void gameOver()
    {
        StopGame();
        PlayerPrefs.Save();
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        buttonText.text = "Restart";
        
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
        initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartButton()
    {
        StopGame(false);
        SceneManager.LoadScene("main");
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
