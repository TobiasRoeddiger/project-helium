using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public void Start() {
		
	}

	public void StartButtonClicked(string name) {
		var startButton = GameObject.Find ("StartButton");
		Destroy (startButton);
	}
}
