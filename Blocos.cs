using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocos : MonoBehaviour {

	private GameObject Boss;
	private bool tocouNoChao;
	private int speedBloco = 5;

	void Start () {
		Boss = GameObject.Find ("Boss");
	}

	void Update () {
		if (transform.position.x > -45 && tocouNoChao) {
			GetComponent<Rigidbody2D> ().isKinematic = true;
			transform.Translate (Vector2.left * Time.deltaTime * speedBloco);
		} else if (transform.position.x < -45) {
			tocouNoChao = false;
			GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.SetActive (false);
			Boss.GetComponent<AtaquesBoss> ().ataque = "Nada";
			Boss.GetComponent<AtaquesBoss> ().InstaBloco = true;
		}
	}
	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.transform.CompareTag("Chao")) {
			tocouNoChao = true;
		}
	}
}
