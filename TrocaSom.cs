using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaSom : MonoBehaviour {

	private AudioSource Source;
	public AudioClip [] clip;
	private AudioClip tocar;

	void Start () {
		tocar = clip[Random.Range(0, clip.Length)];
		Source = GetComponent<AudioSource>();
	}
	

	void Update () {
		print (tocar.name);
		if(!Source.isPlaying){
			Source.PlayOneShot(tocar);
		}
	}
}
