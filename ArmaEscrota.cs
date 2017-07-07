using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEscrota : MonoBehaviour {

	private GameObject Boss;

	//Tiro
	public GameObject energia;
	public float reloadTime = .5f;
	public IniObjPool objPool;
	private float timeForNextShot;
	private bool contagem = false;

	private AudioSource Source;
	//public AudioClip BossSom;

	void Start () {
		Boss = GameObject.Find ("Boss");
		//Source = GetComponent<AudioSource>();
	}
	

	void Update () {
		if (Boss.GetComponent<AtaquesBoss> ().atirar) {
			energia.SetActive (true);
			if (energia.transform.localScale.x < 0.4f && energia.transform.localScale.y < 0.4f) {
				//Tiro
				Vector2 position = new Vector2 (energia.transform.position.x, energia.transform.position.y);
				energia.transform.localScale = new Vector2 (1,1);
				energia.SetActive(false);

				GameObject bullet = objPool.Atirar ();
				bullet.SetActive (true);
				bullet.transform.position = position;
				//Source.PlayOneShot(BossSom);
				Boss.GetComponent<AtaquesBoss> ().atirar = false;
				Boss.GetComponent<AtaquesBoss> ().atirou = true;
			} else {
				if (Time.time >= timeForNextShot) {
					energia.transform.localScale = new Vector2 (energia.transform.localScale.x - 0.01f, energia.transform.localScale.y - 0.01f);
				}
			}
		}
		if (energia.activeInHierarchy && Boss.GetComponent<AtaquesBoss> ().seDesceu) {
			timeForNextShot = Time.time + reloadTime;
			Boss.GetComponent<AtaquesBoss> ().seDesceu = false;
		}
		
	}
	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Pistola")) {
			hit.gameObject.SetActive (false);
			Boss.GetComponent<AtaquesBoss> ().atirou = true;
			Boss.GetComponent<AtaquesBoss> ().atirar = false;
			energia.SetActive(false);
			Boss.GetComponent<AtaquesBoss> ().vida-= 0.5f;
		}
		else if(hit.CompareTag ("Shoutgun")) {
			hit.gameObject.SetActive (false);
			Boss.GetComponent<AtaquesBoss> ().atirou = true;
			Boss.GetComponent<AtaquesBoss> ().atirar = false;
			energia.SetActive(false);
			Boss.GetComponent<AtaquesBoss> ().vida--;
		}
	}
}
