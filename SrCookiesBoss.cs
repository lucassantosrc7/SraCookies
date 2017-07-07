using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SrCookiesBoss : MonoBehaviour {

	public GameObject GameController;
	public Vector2 posIni;
	public GameObject ground;

	public int vida = 3;
	public float speed;
	private Rigidbody2D rb;
	private Vector2 jumpForce = new Vector2(0, 350);

	//Movimentacao

	public float parar;
	public string movimentaPlayer;

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
		transform.position = new Vector2 (-36.4f, transform.position.y);

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
			SceneManager.LoadScene ("Boss");
			vida = 3;
			if(!Source.isPlaying){
				Source.PlayOneShot(Morrer);
			}
		}


		transform.localScale = new Vector3(-1.5f, 2.8f, 1);

		if (GameController.GetComponent<MovimentoBoss>().estadoPlayer == "Chao" && speed > 0) { 
			animacao = "Correr";
			if (!Source.isPlaying) {
				Source.PlayOneShot (Andar);
			}
		}else animacao = "Idle";
		if (!Source.isPlaying) {
			Source.Stop ();
		}

		//Travar Movimentacão
		if (parar == 1) {
			if (movimentaPlayer == "Direita") {
				if (transform.position.x <= -32) {
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}else {
					movimentaPlayer = "Parado";
					parar = 2;
				}
			}
		} else if (parar == 2) {
			if (movimentaPlayer == "Direita") {
				if (transform.position.x <= -28) {
					transform.Translate (Vector2.right * speed * Time.deltaTime);
				}else {
					movimentaPlayer = "Parado";
					parar = 3;
				}
			}else if (movimentaPlayer == "Esquerda") {
				if (transform.position.x >= -36.5f) {
					transform.Translate (Vector2.left * speed * Time.deltaTime);
					ground.GetComponent<Ground> ().parar = true;
				}else {
					movimentaPlayer = "Parado";
					parar = 1;
					ground.GetComponent<Ground> ().parar = false;
				}
			}
		}else if (parar == 3) {
			if (movimentaPlayer == "Esquerda") {
				if (transform.position.x >= -32) {
					transform.Translate (Vector2.left * speed * Time.deltaTime);
					ground.GetComponent<Ground> ().parar = true;
				}else {
					movimentaPlayer = "Parado";
					parar = 2;
					ground.GetComponent<Ground> ().parar = false;
				}
			}
		}

		/*/Ter certeza que não vai bugar

		if(transform.position.x < - 36.5f){
			transform.position = new Vector2 (- 36.5f, transform.position.y);
		}else if(transform.position.x > - 28){
			transform.position = new Vector2 (-28, transform.position.y);
		}*/
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

			GameController.GetComponent<MovimentoBoss>().estadoPlayer = "Chao";
		}
	}
}
