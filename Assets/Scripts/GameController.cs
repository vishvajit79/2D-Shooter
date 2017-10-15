using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField]
    GameObject bird;
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

    // Use this for initialization
    private void initialize () {
        Player.Instance.Score = 0;
        Player.Instance.Health = 100;

        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        StartCoroutine("AddEnemy");
    }

    // Use this for initialization
    void Start()
    {
        Player.Instance.gameCtrl = this;
        initialize();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void gameOver()
    {
        Health.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        CurrentScore.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }

    public void updateUI()
    {
        Health.text = "Health: " + Player.Instance.Health;
        Score.text = "Score: " + Player.Instance.Score;
    }

    public void ResetBtnClick()
    {

        SceneManager.
            LoadScene(
                SceneManager.GetActiveScene().name);

    }

    private IEnumerator AddEnemy()
    {
        int time = Random.Range(10, 20);

        yield return new WaitForSeconds((float)time);
        Instantiate(bird);
        StartCoroutine("AddEnemy");
    }
}
