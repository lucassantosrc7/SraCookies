using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour {

	public GameObject GameController;

	//tiro
	public float reloadTimePistola = .5f;
	public float reloadTimeShoutgun = .5f;
	public ObjPool objPool;
	private float timeForNextShot;
	public GameObject especial;
	public int chamaEspecial;

	//Estado do Player
	public string playerArma = "Pistola";

	private AudioSource Source;
	public AudioClip PistolaSom;
	public AudioClip ShotgunSom;

	void Start () {
		Source = GetComponent<AudioSource>();
	}

	void Update () {
		//Tiro
		Vector2 position = new Vector2(transform.position.x - transform.localScale.x/2, transform.position.y + 0.5f);

		if (Time.time >= timeForNextShot && GameController.GetComponent<Movimento>().atirar)
		{
			if (playerArma == "Pistola") {
				GameObject bullet = objPool.Pistola ();
				bullet.SetActive (true);
				bullet.transform.position = position;
				timeForNextShot = Time.time + reloadTimePistola;
				Source.PlayOneShot(PistolaSom);
			}
			else if (playerArma == "Shotgun") {
				GameObject bullet = objPool.Shotgun ();
				bullet.SetActive (true);
				bullet.transform.position = position;
				timeForNextShot = Time.time + reloadTimeShoutgun;
				Source.PlayOneShot(ShotgunSom);
			}
		}

		if (chamaEspecial > 20) {
			especial.gameObject.SetActive(true);
		}
	}
}
