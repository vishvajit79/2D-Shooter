using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    [SerializeField]
    private Text Health;
    [SerializeField]
    private Text Score;

    private static int _highScore;
    private static int currentScore;
    private static bool gameOver;
    private Player player;
    private GameController gameController;
    private static GameplayController Instance;

    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            if (currentScore > _highScore)
            {
                _highScore = currentScore;
                PlayerPrefs.SetInt("highScore", _highScore);
                gameController.updateUI();
            }
        }
    }

    public static int CurrentScore
    {

        get { return currentScore; }
        set
        {
            currentScore = value;
            if (currentScore > _highScore)
            {
                _highScore = currentScore;
            }
        }
    }

    // When this becomes true, starts GameOverCoroutine which makes the player
    // flashe for 5 seconds. 
    public static bool GameOver
    {

        get { return gameOver; }
        set
        {
            gameOver = value;

            if (gameOver)
            {
                Instance.gameController = GameController.Instance;
                PlayerPrefs.Save();
                Instance.gameController.Menu.text = "GameOver";
                Instance.gameController.HighScore.text = "High Score: " + highScore.ToString();
                Instance.gameController.buttonText.text = "Restart";
                Instance.menu.button.onClick.AddListener(
                    () => {
                        SceneManager.LoadScene("Main");
                    }
                );
                Instance.menu.enabled = true;
                Instance.menu.StopGame();
            }
        }
    }

    // Methods //

    // Initializing properties.
    void Awake()
    {

        Instance = this;
        player = GameObject.Find("Player").GetComponent<Player>();
        gameController = GameObject.Find("Canvas").GetComponent<GameController>();
        HighScore = PlayerPrefs.GetInt("highScore");
    }

    // Updates the text in the Text objects in the HUD, as well keeping track 
    // of the topScore. If Cancel is pressed, the game is paused and the menu,
    // screen is brought up.
    void Update()
    {

        Health.text = formatStatusText("Health:", player.health);
        Score.text = "Score: " + Score.ToString().PadLeft(11);



        if (Input.GetButtonDown("Cancel"))
        {
            PlayerPrefs.SetInt("TopScore", topScore);
            menuScreen("Paused", "Resume");
        }
    }

    // Pads the strings for status info for continuity.
    string formatStatusText(string key, int value)
    {

        return key.PadRight(7) + value.ToString().PadLeft(3);
    }

    // Generates the string for the menuText. Then changes the Text.text for 
    // the button in the menu. Followed by pausing the game.
    void menuScreen(string menuType, string buttonText)
    {

        gameController.Menu.text = menuType +
            "\nScore:" + currentScore.ToString().PadLeft(11) +
            "\nTop Score: " + _highScore.ToString().PadLeft(7);
        gameController.gamePaused = !gameController.gamePaused;
        gameController.buttonText.text = buttonText;
        gameController.StopGame(gameController.gamePaused);
    }
}
