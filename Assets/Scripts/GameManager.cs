using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum GameState {
	start,
	inGame,
	gameOver,
	levelComplete,
	youWin
}

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public GameState currentGameState = GameState.start;

	public GameObject StartScreen;
    public GameObject InGameScreen;
    public GameObject GameOverScreen;
	public GameObject YouWonScreen;

    public float timer;
    public string seconds;
    public bool _timeStarted = false;

	public void Awake () {
		Instance = this;
	}

	public void StartGame() {
		SetGameState (GameState.inGame);
        Ball.Instance.StartGame();
        _timeStarted = true;
	}

	public void GameOver() {
		SetGameState (GameState.gameOver);
        _timeStarted = false;
    }

	public void YouWon() {
		SetGameState (GameState.youWin);
        _timeStarted = false;
        Destroy(Ball.Instance.gameObject);
	}

	public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void RestartGame ()
    {
        SceneManager.LoadScene("Level1");
    }

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.start) {
			StartScreen.SetActive(true);
            InGameScreen.SetActive(false);
			GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.inGame) {
			StartScreen.SetActive (false);
            InGameScreen.SetActive(true);
            GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.levelComplete) {
			StartScreen.SetActive (false);
            InGameScreen.SetActive(false);
            GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.gameOver) {
			StartScreen.SetActive (false);
            InGameScreen.SetActive(false);
            GameOverScreen.SetActive(true);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.youWin) {
			StartScreen.SetActive (false);
            InGameScreen.SetActive(false);
            GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (true);
		}
		currentGameState = newGameState;
	}

    void Update()
    {
        if (_timeStarted == true)
        {
            timer += Time.deltaTime;
            seconds = (timer).ToString("0000");
        }
    }
}
