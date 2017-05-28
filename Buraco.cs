using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player") || hit.CompareTag("Inimigo"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
