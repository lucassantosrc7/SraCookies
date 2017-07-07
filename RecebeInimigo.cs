using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecebeInimigo : MonoBehaviour {

	public GameObject [] inimigo;
	public GameObject player;

	void Start () {
		
	}
	

	void Update () {
		if(player.GetComponent<SraCookies>().vida < 0){
			for(int i = 0; i < inimigo.Length; i++){
				inimigo[i].SetActive(true);
			}
		}

	}
}
