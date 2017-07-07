﻿using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using System;
using UnityEngine;


public class Movimento : MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    private Vector2 posZero;
    private Vector2 posCam;
	public bool troucouFase = false;

    //movimento
    public string estadoPlayer = "Chao";
    private Vector2 final;

    public bool atirar = false;

    void Start () {
        transform.position = new Vector2(cam.transform.position.x, cam.transform.position.y);
    }

    void Update() {

		if(troucouFase){
			player.GetComponent<SraCookies> ().speed = 0;
			estadoPlayer = "Chao";
			troucouFase = false;
		}

        posCam = new Vector2(cam.transform.position.x, cam.transform.position.y);

        /////Movimentacao/////

        if (final.x > 1.5f)
        {
			final.x = 0;
			if (player.GetComponent<SraCookies> ().speed <= 0) {
				player.GetComponent<SraCookies> ().speed += 7;
			}
			else if (player.GetComponent<SraCookies> ().speed >= 7 && player.GetComponent<SraCookies> ().speed < 13) {
				player.GetComponent<SraCookies> ().speed += 3;
			}
        }
        if (final.x < -1.5f)
        {
			final.x = 0;
			if (player.GetComponent<SraCookies> ().speed > 7 && player.GetComponent<SraCookies> ().speed <= 13) {
				player.GetComponent<SraCookies> ().speed -= 3;
			}
        }

        /////Pulo/////
        if (final.y > 1.5f && estadoPlayer == "Chao")
        {
            player.GetComponent<SraCookies>().Cima();
            estadoPlayer = "Cima1";
            final.y = 0;
        } else if (final.y > 1.5f && estadoPlayer == "Cima1")
        {
            player.GetComponent<SraCookies>().Cima();
            estadoPlayer = "Cima";
            final.y = 0;
        }
        /////Granada/////
        else if (final.y  < -1.5f) {
            atirar = true;
            final.y = 0;
        }

    }

    void OnEnable()
    {
        GetComponent<ReleaseGesture>().Released += Mover;
        GetComponent<PressGesture>().Pressed += PegarPos;
        GetComponent<LongPressGesture>().LongPressed += Atirar;
    }
    void OnDisable()
    {
        GetComponent<ReleaseGesture>().Released -= Mover;
        GetComponent<PressGesture>().Pressed -= PegarPos;
        GetComponent<LongPressGesture>().LongPressed -= Atirar;
    }

    void PegarPos(object sender, EventArgs e)
    {
        posZero = transform.position;
    }

    void Mover(object sender, EventArgs e) {
        final = new Vector2(transform.position.x - posZero.x, transform.position.y - posZero.y); ;
        transform.position = posCam;
        atirar = false;
    }
    void Atirar(object sender, EventArgs e) {
        atirar = true;
    }
}
