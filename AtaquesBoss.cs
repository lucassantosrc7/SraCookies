using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesBoss : MonoBehaviour {

	public float vida;
	public GameObject controlMenu;
	public GameObject playerEstado;
	public GameObject Player;

	private int time = 40;
	private Rigidbody2D rb;

	//Variaveis para ataque
		//Bomba
		private float timeForNextShot;
		public float reloadTimePistola = .5f;

		public GameObject Sombra;
		private GameObject tiro;
		public GameObject tiroPrefab;
		private GameObject tiro2;
		public GameObject tiroPrefab2;
		public bool tiroB = true;

			//Diminuir Sombras
			private float distancia;
			
			private float tMXS;
			public float tMNS = 6; //Tamanho Minimo da sombra
			private float dMX; //Distancia Maxima
			public float dMN = 0; //Distancia Minima

			private float x;
		//Arma Escrota
		public GameObject Arma;
		private float posArmaIni;
		private float posArma;
		public bool atirou = false; //se o player atirou
		public bool atirar = false; //se a arma atirou
		public bool seDesceu = false;

		//Blocos
		public GameObject [] blocos;
		private GameObject bloco;
		private GameObject [] blocoPrefb;
		public bool InstaBloco = true;

	//Chamar Ataques
	public string ataque = "Nada";
	public bool ataqueBombaBool = false;


	void Start () {
		
		for (int i = 0; i < blocos.Length; i++) {
			blocos [i].SetActive(false);
		}

		posArma = Random.Range (-2f, 0f);
		posArmaIni = Arma.transform.position.y;

		tMXS = Sombra.transform.localScale.x;

		Sombra.SetActive (false);

		rb = GetComponent<Rigidbody2D>();
	}


	void Update () {

		Blocos ();

		/*
		if (vida >= 10) {
			ArmaEscrota ();
		} else if (vida >= 9 && vida < 10 && ataque == "Blocos") {
			Blocos ();
		} else if (vida >= 7 && vida < 10 && ataque == "Nada") {
			ArmaEscrota ();
			ataqueBombaBool = true;
		} else if (vida >= 6 && vida < 7 && ataqueBombaBool) {
			AtaqueBomba ();
		} else if (vida >= 2 && vida < 7 && !ataqueBombaBool) {
			ArmaEscrota ();
			Blocos ();
		}
		else if (vida > 0 && vida < 2) { 
			AtaqueBomba ();
			if (transform.position.y > -4) {
				transform.Translate (Vector2.down * Time.deltaTime * 8);
			}
		}
		else if (vida <= 0) {
			controlMenu.SendMessage ("ChangeScreen", ControlMenu.Screens.gameover);
		}*/
	}
	public void AtaqueBomba(){
		
		if (tiroB) {
			tiro = Instantiate (tiroPrefab);
			tiro.GetComponent<Rigidbody2D> ().gravityScale = 0;
			tiro.transform.position = new Vector2 (transform.position.x - 1, transform.position.y + 4);
			tiro.transform.eulerAngles = new Vector3 (0, 0, 295);
			timeForNextShot = Time.time + reloadTimePistola;
			tiroB = false;
		} else if (tiro.transform.position.y < 13 && Time.time >= timeForNextShot) {
			tiro.transform.Translate (Vector2.left);
		} else if (tiro.transform.position.y >= 13 && tiro.activeInHierarchy == true) {
			tiro.SetActive (false);
			Sombra.SetActive (true);
			Sombra.transform.position = new Vector2 (Player.transform.position.x + Random.Range(-5,5), Sombra.transform.position.y);

			tiro2 = Instantiate (tiroPrefab2);
			tiro2.GetComponent<Rigidbody2D> ().gravityScale = 1;
			tiro2.transform.eulerAngles = new Vector3 (0, 0, 90);
			tiro2.transform.position = new Vector2 (Sombra.transform.position.x, tiro.transform.position.y);
		} 
		else if(Sombra.activeInHierarchy == true) {
			//Diminuir Sombra 
			dMX = tiro2.transform.position.y;
			distancia = Mathf.Abs (dMX - dMN);

			x =  distancia + tMNS;
			Sombra.transform.localScale = new Vector2(x, Sombra.transform.localScale.y);
		}
	}
	void ArmaEscrota(){
		if (!atirou) {
			if (Arma.transform.position.y > posArma) {
				seDesceu = true;
				Arma.transform.Translate (Vector2.down * Time.deltaTime * 5);
			} else
				atirar = true;
		} else {
			if (Arma.transform.position.y < posArmaIni) {
				Arma.transform.Translate (Vector2.up * Time.deltaTime * 5);
			} else {
				posArma = Random.Range (-2f, 0f);
				atirou = false;
			}
		}
	}

	void Blocos(){
		if (InstaBloco) {
			InstaBloco = false;
			bloco = blocos [Random.Range (0, blocos.Length)];
			bloco.transform.position = transform.position;
			bloco.SetActive (true);
		}
	}
	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Pistola")) {
			hit.gameObject.SetActive (false);
			vida-= 0.5f;
		}
		if (hit.CompareTag ("Shoutgun")) {
			hit.gameObject.SetActive (false);
			vida--;
		}
	}
}
