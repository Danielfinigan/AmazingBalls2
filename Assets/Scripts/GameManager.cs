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

	public void Awake () {
		Instance = this;
	}

	public void StartGame() {
		SetGameState (GameState.inGame);
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.start) {
			StartScreen.SetActive(true);
		} else if (newGameState == GameState.inGame) {
			StartScreen.SetActive (false);
		} else if (newGameState == GameState.levelComplete) {
			StartScreen.SetActive (false);
		} else if (newGameState == GameState.gameOver) {
			StartScreen.SetActive (false);
		} else if (newGameState == GameState.youWin) {
			StartScreen.SetActive (false);
		}
		currentGameState = newGameState;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
