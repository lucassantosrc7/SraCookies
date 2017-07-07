using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FaseBoss : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("Player"))
		{
			SceneManager.LoadScene ("Boss");
		}
	}
}
