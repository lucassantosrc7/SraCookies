using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour {

    public bool especial = true;
    public int quantoMatou = 0;

	void Update () {
        if (quantoMatou >= 5) {
            especial = false;
            quantoMatou = 0;
            gameObject.SetActive(false);
        }
	}
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Inimigo") && especial)
        {
            Destroy(hit.gameObject);
            quantoMatou++;
        }
    }
}
