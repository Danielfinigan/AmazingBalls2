using UnityEngine;
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
	public GameObject GameOverScreen;
	public GameObject YouWonScreen;

	public void Awake () {
		Instance = this;
	}

	public void StartGame() {
		SetGameState (GameState.inGame);
	}

	public void GameOver() {
		SetGameState (GameState.gameOver);
	}

	public void YouWon() {
		SetGameState (GameState.youWin);
	}

	public void RestartLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void RestartGame () {
		Application.LoadLevel ("Level1");
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.start) {
			StartScreen.SetActive(true);
			GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.inGame) {
			StartScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.levelComplete) {
			StartScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.gameOver) {
			StartScreen.SetActive (false);
			GameOverScreen.SetActive(true);
			YouWonScreen.SetActive (false);
		} else if (newGameState == GameState.youWin) {
			StartScreen.SetActive (false);
			GameOverScreen.SetActive(false);
			YouWonScreen.SetActive (true);
		}
		currentGameState = newGameState;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
