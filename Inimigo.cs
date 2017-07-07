using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    public float reloadTime = .2f;
    public IniObjPool objPool;
    private float timeForNextShot;
    private bool atirar;
	public GameObject inimigo;

	private AudioSource Source;
	public AudioClip PistolaSom;

	void Start () {
		Source = GetComponent<AudioSource>();
	}

    void Update() {

        if (atirar) {
            Vector2 position = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y + 1);
			inimigo.GetComponent<Animator> ().SetBool ("Preparar", true);
            if (Time.time >= timeForNextShot)
            {
                GameObject bullet = objPool.Atirar();
                bullet.SetActive(true);
                bullet.transform.position = position;
                timeForNextShot = Time.time + reloadTime;
				inimigo.GetComponent<Animator> ().SetBool ("Atirar", true);
				Source.PlayOneShot(PistolaSom);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
			hit.GetComponent<SraCookies> ().speed = 0;
			timeForNextShot = Time.time + reloadTime;
            atirar = true;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
			hit.GetComponent<SraCookies> ().speed = 7;
			timeForNextShot = Time.time + reloadTime;
            atirar = false;
        }
    }
}
