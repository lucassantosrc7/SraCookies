using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour {

    private GameObject player;
    private string ladoPlayer;
    public float speed = 12;
    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
        player = GameObject.Find("Player");
        if (player.transform.localScale.x > 0)
        {
            ladoPlayer = "Esquerda";
        }
        else ladoPlayer = "Direita";
    }

    void Update()
    {
        if(ladoPlayer == "Direita")
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x < pos.x - 20)
                gameObject.SetActive(false);
        }
        if (ladoPlayer == "Esquerda")
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x > pos.x + 20)
                gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.CompareTag("Inimigo"))
        {
            gameObject.SetActive(false);
            Destroy(hit.gameObject);
            player.GetComponent<SraCookies>().chamaEspecial++;
        }
    }
}
