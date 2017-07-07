using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1 : MonoBehaviour {

	public GameObject chamaFase;

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("Player"))
		{
			chamaFase.SendMessage ("ChangeScreen", ChamaFase.Screens.boss);
		}
	}
}
