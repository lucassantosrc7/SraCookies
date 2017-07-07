using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJogador : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("Player"))
		{
			hit.gameObject.GetComponent<SrCookiesBoss>().vida = 0;
			Destroy(gameObject);
		}
	}
}
