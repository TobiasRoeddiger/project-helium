using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	private GameObject detectingObject;
	bool running = false;

	public void Start() {
		detectingObject = GameObject.Find ("DetectingObjectText");
		detectingObject.SetActive (false);
	}

	public void StartButtonClicked(string name) {
		detectingObject.SetActive (true);
		running = true;
		var startButton = GameObject.Find ("StartButton");
		Destroy (startButton);
	}

	private float timeLeft = 5;
	public void Update()
	{
		if (running) {
			timeLeft -= (float)Time.deltaTime;
			if (timeLeft < 0.0f)
			{
				running = false;
				detectingObject.SetActive (false);
			}
		}
	}
}
