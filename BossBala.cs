using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBala : MonoBehaviour {

	public float speed = 12;
	private Vector2 pos;

	private float timeForNextShot;

	void Start()
	{
		pos = transform.position;
	}

	void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
		if (transform.position.x > pos.x + 20)
			gameObject.SetActive(false);

	}
	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.transform.CompareTag("Player"))
		{
			gameObject.SetActive(false);
			hit.gameObject.GetComponent<SrCookiesBoss>().vida--;
		}
	}
}
