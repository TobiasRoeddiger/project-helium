using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenueScript : MonoBehaviour {

	private float y;
	private float goal;
	private float step = 5;

	private GameObject wrapper;

	// Use this for initialization
	void Start () {
		y = -350;
		goal = 0;
		wrapper = GameObject.Find ("MenueWrapper");

		FillMenu ();
	}
	
	// Update is called once per frame
	void Update () {
		if (y < goal) {
			var wrt = wrapper.GetComponent<RectTransform> ().localPosition;
			y += step;
			wrapper.GetComponent<RectTransform> ().localPosition = new Vector3 (wrt.x, y, wrt.z);
		}
	}

	void FillMenu() {
		MaterialSample s = MaterialSample.SelectedSample;

		GameObject.Find ("MenueWrapper/FamilyName").GetComponent<Text> ().text = s.Name;
		GameObject.Find ("MenueWrapper/PropertiesValues").GetComponent<Text> ().text = string.Format("{0}\n{1}\n{2}", s.Density, s.TensileStrength, s.ElongationAtRupture);
	}
}
