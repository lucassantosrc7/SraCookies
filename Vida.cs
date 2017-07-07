using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {

	public Image i1;
	public Image i2;
	public Image i3;
	public Image i4;
	public Image i5;

	void Start () {
		i1.gameObject.SetActive (false);
		i2.gameObject.SetActive (false);
		i3.gameObject.SetActive (false);
		i4.gameObject.SetActive (false);
		i5.gameObject.SetActive (false);
	}

	void Update () {
		if (GetComponent<SraCookies> ().vida == 1) {
			i1.gameObject.SetActive (true);
			i2.gameObject.SetActive (false);
			i3.gameObject.SetActive (false);
			i4.gameObject.SetActive (false);
			i5.gameObject.SetActive (false);
		} else if (GetComponent<SraCookies> ().vida == 2) {
			i1.gameObject.SetActive (true);
			i2.gameObject.SetActive (true);
			i3.gameObject.SetActive (false);
			i4.gameObject.SetActive (false);
			i5.gameObject.SetActive (false);
		} else if (GetComponent<SraCookies> ().vida == 3) {
			i1.gameObject.SetActive (true);
			i2.gameObject.SetActive (true);
			i3.gameObject.SetActive (true);
			i4.gameObject.SetActive (false);
			i5.gameObject.SetActive (false);
		} else if (GetComponent<SraCookies> ().vida == 4) {
			i1.gameObject.SetActive (true);
			i2.gameObject.SetActive (true);
			i3.gameObject.SetActive (true);
			i4.gameObject.SetActive (true);
			i5.gameObject.SetActive (false);
		} else if (GetComponent<SraCookies> ().vida >= 5) {
			i1.gameObject.SetActive (true);
			i2.gameObject.SetActive (true);
			i3.gameObject.SetActive (true);
			i4.gameObject.SetActive (true);
			i5.gameObject.SetActive (true);
		}
		else {
			i1.gameObject.SetActive (false);
			i2.gameObject.SetActive (false);
			i3.gameObject.SetActive (false);
			i4.gameObject.SetActive (false);
			i5.gameObject.SetActive (false);
		}
	}
}
