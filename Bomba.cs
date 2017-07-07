using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

	private GameObject Boss;
	private GameObject Explosao;
	public GameObject explosaoPrefab;

	void Start () {
		Boss = GameObject.Find ("Boss");
	}

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Player")) {
			Explosao = Instantiate (explosaoPrefab);
			Explosao.transform.position = new Vector2(transform.position.x, Explosao.transform.position.y);
			hit.GetComponent<SrCookiesBoss> ().vida--;
			gameObject.SetActive (false);
			Boss.GetComponent<AtaquesBoss> ().tiroB = true;
			Boss.GetComponent<AtaquesBoss> ().ataqueBombaBool = false;
		}
		if (hit.CompareTag ("Chao")) {
			Explosao = Instantiate (explosaoPrefab);
			Explosao.transform.position = new Vector2(transform.position.x, Explosao.transform.position.y);
			gameObject.SetActive (false);
			Boss.GetComponent<AtaquesBoss> ().tiroB = true;
			Boss.GetComponent<AtaquesBoss> ().ataqueBombaBool = false;
		}
	
	}
}
