using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

	private float speed = 40;
    private Vector2 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
		if (transform.position.x < pos.x - 20)
		gameObject.SetActive(false);
    }

}
