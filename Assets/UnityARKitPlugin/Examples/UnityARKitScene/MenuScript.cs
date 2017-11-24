using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	private GameObject detectingObject;
	private GameObject steeringWheel;
	bool running = false;
	public float timer;

	public void Start() {
		detectingObject = GameObject.Find ("DetectingObjectText");
		detectingObject.SetActive (false);

		steeringWheel = GameObject.Find ("SteeringWheel");
		//steeringWheel.SetActive (false);

	}

	public void StartButtonClicked(string name) {
		detectingObject.SetActive (true);
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
