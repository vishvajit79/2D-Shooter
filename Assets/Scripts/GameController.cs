using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
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
    [SerializeField]
    GameObject[] gamePlayObjects;
    public bool gamePaused;
    public GameController Instance;

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
        button = GetComponentInChildren<Button>();
        buttonText = button.GetComponentInChildren<Text>();
        Menu = GetComponentInChildren<Text>();
        gamePaused = false;
        gamePlayObjects = new GameObject[] {
                                                 GameObject.Find("Gameplay")};
        button.onClick.AddListener(
            () => {
                gamePaused = !gamePaused;
                StopGame(false);
            });
    }

    private void initialize()
    {

        Player.Instance.Score = 0;
        Player.Instance.Health = 100;

        HighScore.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        CurrentScore.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        HighScore.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void updateUI()
    {
        HighScore.text = "High Score: " + Player.Instance.HighScore;
        CurrentScore.text = "Your Score: " + Player.Instance.Score;
    }

    // Use this for initialization
    void Start()
    {
        gamePaused = true;
        Player.Instance.gameController = this;
        initialize();
        StopGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") ||
               (Menu.text == "Paused" &&
                Input.GetButtonDown("Cancel")))
        {
            StopGame(false);

        }
    }

    // Pauses or resumes the game by changing the Time.timeScale.
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
