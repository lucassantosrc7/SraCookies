using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniBala : MonoBehaviour {

    private GameObject inimigo;
    private string ladoInimigo;
    public float speed = 12;
    private Vector2 pos;

    public bool Imune = false;
    private float reloadTime = .2f;
    private float timeForNextShot;

    void Start()
    {
        pos = transform.position;
        inimigo = GameObject.Find("Inimigo");
        if (inimigo.transform.localScale.x > 0)
        {
            ladoInimigo = "Esquerda";
        }
        else ladoInimigo = "Direita";
    }

    void Update()
    {
        if (ladoInimigo == "Direita")
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x < pos.x - 20)
                gameObject.SetActive(false);
        }
        if (ladoInimigo == "Esquerda")
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x > pos.x + 20)
                gameObject.SetActive(false);
        }

        if(Imune) timeForNextShot = Time.time + reloadTime;
        if (Time.time >= timeForNextShot) Imune = false;
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.transform.CompareTag("Player") && !Imune)
        {
            gameObject.SetActive(false);
            hit.gameObject.GetComponent<SraCookies>().vida--;
            Imune = true;
        }
    }
}
