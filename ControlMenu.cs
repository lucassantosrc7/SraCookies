using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour {

	public GameObject MenuInGame;
	public GameObject gameOver;

	public enum Screens{
		menuIngame, jogo, gameover
	}

	private Screens actualScreen;
	private Screens lastScreen;

	void Start () {
		MenuInGame.SetActive(false);
		gameOver.SetActive(false);

    }
	public void ChangeScreen(Screens newScreen){

		switch (lastScreen) {
		case Screens.menuIngame:
			MenuInGame.SetActive (false);
			break;

		case Screens.gameover:
			gameOver.SetActive (false);
			break;

		}

		switch (newScreen) {
		case Screens.menuIngame:
			MenuInGame.SetActive (true);
			break;
		
		case Screens.gameover:
			gameOver.SetActive (true);
			break;
		}
		lastScreen = newScreen;
	}
}
