using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SraCookies : MonoBehaviour
{

    public GameObject GameController;

    public int vida = 15;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 jumpForce = new Vector2(0, 350);

    //tiro
    public float reloadTime = .2f;
    public ObjPool objPool;
    private float timeForNextShot;
    public GameObject especial;
    public int chamaEspecial;

    //Estado do Player
    public string playerArma = "Pistola";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Tiro
		Vector2 position = new Vector2(transform.position.x - transform.localScale.x/2, transform.position.y + 0.5f);

        if (Time.time >= timeForNextShot && GameController.GetComponent<Movimento>().atirar)
        {
			if (playerArma == "Pistola") {
				GameObject bullet = objPool.Pistola ();
				bullet.SetActive (true);
				bullet.transform.position = position;
				timeForNextShot = Time.time + reloadTime;
			}
			else if (playerArma == "Shotgun") {
				GameObject bullet = objPool.Shotgun ();
				bullet.SetActive (true);
				bullet.transform.position = position;
				timeForNextShot = Time.time + reloadTime;
			}
        }

        if (chamaEspecial > 20) {
            especial.gameObject.SetActive(true);
        }
    }

    public void Cima()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce);
    }

    public void Esquerda()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        transform.localScale = new Vector3(1.5f, 2.8f, 1);
    }

    public void Direita()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.localScale = new Vector3(-1.5f, 2.8f, 1);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.CompareTag("Chao")) {
            GameController.GetComponent<Movimento>().estadoPlayer = "Chao";
        }
    }
}
