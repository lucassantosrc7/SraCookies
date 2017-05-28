using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocadeArmas : MonoBehaviour {

	public GameObject player;

	public GameObject pistola;
	public GameObject shotgun;
    public GameObject especial;

	public void Pistola(){
		pistola.SetActive (true);
		shotgun.SetActive (false);
		player.GetComponent<SraCookies>().playerArma = "Pistola";
	}
	public void Shotgun(){
		pistola.SetActive (false);
		shotgun.SetActive (true);
		player.GetComponent<SraCookies>().playerArma = "Shotgun";
	}
    public void Especial() {
        especial.GetComponent<Especial>().especial = true;
    }
}
