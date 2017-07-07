using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniVida : MonoBehaviour {

	private GameObject player;
	private int vida = 2;

	void Start () {
		player = GameObject.Find ("Player");
	}

	void Update() {

		if (vida <= 0) {
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.transform.CompareTag("Pistola"))
		{
			vida--;
			hit.gameObject.SetActive(false);
			player.GetComponent<TiroPlayer>().chamaEspecial++;
			player.GetComponent<SraCookies> ().speed = 7;
		}
		if (hit.transform.CompareTag("Shoutgun"))
		{
			vida -= 2;
			hit.gameObject.SetActive(false);
			player.GetComponent<TiroPlayer>().chamaEspecial++;
			player.GetComponent<SraCookies> ().speed = 7;
		}
	}
}
