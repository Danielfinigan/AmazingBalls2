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
    public float score;
    public bool timeStarted = false;
    public bool speedIncrease = false;

	public void Awake () {
		Instance = this;
	}

	public void StartGame() {
		SetGameState (GameState.inGame);
        Ball.Instance.StartGame();
        timeStarted = true;
	}

	public void GameOver() {
		SetGameState (GameState.gameOver);
        timeStarted = false;
    }

	public void YouWon() {
		SetGameState (GameState.youWin);
        timeStarted = false;
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

    //add points to score based how quickly bricks are destroyed
    public void Addpoints()
    {
        float add = 10;     //default score per brick = 10
        if (timer < 15)     //under 30 seconds
            add *= 5;
        else if (timer < 30)
            add *= 3;
        else if (timer < 60)    //under 60 seconds
            add *= 2;
        score += add;
    }
    void Update()
    {
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
            if (timer % 30 == 0 && speedIncrease)
            {
                Ball.Instance.increaseSpeed();
                speedIncrease = false;
            }
            if (timer % 30 == 1)
                speedIncrease = true;
        }
    }
}
