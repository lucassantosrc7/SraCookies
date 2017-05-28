using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escultar : MonoBehaviour {

    public GameObject player;
    private bool escultou = false; 

	void Update () {
		if (escultou && player.transform.position.x > transform.position.x)  transform.localScale = new Vector3(-1.5f, 2.8f, 1);
		else if (escultou && player.transform.position.x < transform.position.x)  transform.localScale = new Vector3(1.5f, 2.8f, 1);
	}

    void OnTriggerEnter2D(Collider2D hit) {
        if (hit.CompareTag("Player")) {
            escultou = true;
        }
    }
	void OnTriggerExit2D(Collider2D hit) {
		if (hit.CompareTag("Player")) {
			escultou = false;
		}
	}
}
