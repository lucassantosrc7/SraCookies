using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamaFase : MonoBehaviour {

	public GameObject player;
	public GameObject movimento;

	public GameObject Fase1;
	public GameObject Fase1Comeco;

	public GameObject Boss;
	public GameObject BossComeco;


	public enum Screens{
		fase1, boss
	}

	private Screens actualScreen;
	private Screens lastScreen;

	void Start () {
		Fase1.SetActive(true);
		Boss.SetActive(false);
	}
	public void ChangeScreen(Screens newScreen){

		switch (lastScreen) {
		case Screens.fase1:
			Fase1.SetActive (false);
			break;
		
		case Screens.boss:
			Boss.SetActive (false);
			break;

		}

		switch (newScreen) {

		case Screens.fase1:
			Fase1.SetActive (true);
			player.transform.position = Fase1Comeco.transform.position;
			movimento.GetComponent<Movimento> ().troucouFase = true;
			break;

		case Screens.boss:
			Boss.SetActive (true);
			player.transform.position = BossComeco.transform.position;
			movimento.GetComponent<Movimento>().troucouFase = true;
			break;

		}

		lastScreen = newScreen;
	}
}
