using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AcoesMenu : MonoBehaviour {
	
	public GameObject controlMenu;

	void Start () {
	}

	void Update () {
		
	}

	public void Jogar(){
		SceneManager.LoadScene ("Game");
	}
	public void Sair(){
		Application.Quit ();
	}
	public void pause(){
		Time.timeScale = 0;
		controlMenu.SendMessage ("ChangeScreen", ControlMenu.Screens.menuIngame);
	}
	public void VoltarJogo(){
		controlMenu.SendMessage ("ChangeScreen", ControlMenu.Screens.jogo);
		Time.timeScale = 1;
	}
	public void Menu(){
		SceneManager.LoadScene ("Menu");
		print("sdaasd");
	}
}
