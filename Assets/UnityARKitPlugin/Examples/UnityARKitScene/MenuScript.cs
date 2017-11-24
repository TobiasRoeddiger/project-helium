using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	private GameObject detectingObject;

	public void Start() {
		detectingObject = GameObject.Find ("StartButton");
		detectingObject.SetActive (false);
	}

	public void StartButtonClicked(string name) {
		detectingObject.SetActive (true);
		var startButton = GameObject.Find ("StartButton");
		Destroy (startButton);
	}
}
