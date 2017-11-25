using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuScript : MonoBehaviour {

	private GameObject detectingObject;
	private GameObject steeringWheel;
	private GameObject loadingStrip;
	bool running = false;
	public float timer;
	float radius;

	public void Start() {
		detectingObject = GameObject.Find ("DetectingObjectText");
		detectingObject.SetActive (false);

		steeringWheel = GameObject.Find ("SteeringWheel");
		//steeringWheel.SetActive (false);

		loadingStrip = GameObject.Find ("LoadingStrip");
		radius = loadingStrip.GetComponent<RectTransform> ().offsetMin [0];
		loadingStrip.SetActive (false);
	}

	public void StartButtonClicked(string name) {
		detectingObject.SetActive (true);
		loadingStrip.SetActive (true);
		running = true;
		var startButton = GameObject.Find ("StartButton");
		Destroy (startButton);
	}

	private float timeLeft = 3;
	public void Update()
	{

		if (running) {
			//Blinking function:
			timer += Time.deltaTime;
			if (timer >= 0.5) {
				detectingObject.SetActive (false);
			}
			if (timer > 1) {
				detectingObject.SetActive (true);
				timer = 0;
			}

			// Animate loading strip
			float x = (float) (Math.Sin ((double) timeLeft * Math.PI) * radius);
			var ldt = loadingStrip.GetComponent<RectTransform> ();
			loadingStrip.GetComponent<RectTransform>().offsetMin = new Vector2 (radius + x, ldt.offsetMin[1]);
			loadingStrip.GetComponent<RectTransform>().offsetMax = new Vector2 (-(radius - x), ldt.offsetMax[1]);

			//END Blinking function
			timeLeft -= (float)Time.deltaTime;
			if (timeLeft < 0.0f)
			{
				running = false;
				detectingObject.SetActive (false);
				SceneManager.LoadScene ("SteeringWheelScene", LoadSceneMode.Single);
			}
		}
	}
}
