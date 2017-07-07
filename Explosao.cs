using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour {

	private float time;

	void Start () {
		time = Time.time;
	}
	

	void Update () {
		print (time);
		if (Time.time > time + 0.5f) {
			gameObject.SetActive (false);
		}
	}
}
