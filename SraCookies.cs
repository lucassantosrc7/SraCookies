using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SraCookies : MonoBehaviour {

    public GameObject GameController;
	public Vector2 posIni;

    public int vida = 3;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 jumpForce = new Vector2(0, 350);

	private Animator anim;
	private string animacao;
	private string animacaoAntiga;

	private AudioSource Source;
	private AudioClip atual;
	private AudioClip antiga;
	public AudioClip Pular;
	public AudioClip Andar;
	public AudioClip Morrer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		posIni = transform.position;

		Source = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
    }


    void Update()
    {

		if(animacao != animacaoAntiga){
			anim.SetBool(animacaoAntiga, false);
			animacaoAntiga = animacao;
		}else{ anim.SetBool(animacaoAntiga, true);}


		if (vida == 0) {
			vida--;
		}
		else if(vida <= -1){
			transform.position = posIni;
			vida = 3;
			if(!Source.isPlaying){
				Source.PlayOneShot(Morrer);
			}
		}

		transform.Translate(Vector2.right * speed * Time.deltaTime);
		transform.localScale = new Vector3(-1.5f, 2.8f, 1);

		if (GameController.GetComponent<Movimento> ().estadoPlayer == "Chao" && speed > 0) { 
			animacao = "Correr";
			if (!Source.isPlaying) {
				Source.PlayOneShot (Andar);
			}
		} else {
			animacao = "Idle";
			if (!Source.isPlaying) {
				Source.Stop ();
			}
		}
    }

    public void Cima()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce);
		Source.Stop ();
		Source.PlayOneShot (Pular);
		animacao = "Pular";
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.CompareTag("Chao")) {
			
            GameController.GetComponent<Movimento>().estadoPlayer = "Chao";
        }
    }
}
