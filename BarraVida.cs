using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraVida : MonoBehaviour {

	public Slider slide;

	void Update () {
		slide.value = GetComponent<AtaquesBoss> ().vida;
	}
}
