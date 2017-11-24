using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheelScript : MonoBehaviour {

	private GameObject toggleButton;
	private GameObject steeringWheel;
	private GameObject Hud;
	public float timer;

	private bool _toggleState;
	public bool toggleState {
		get {
			return _toggleState;
		}
		set {
			_toggleState = value;
			Hud.SetActive (value);
			toggleButton.GetComponentInChildren<Text>().text = (_toggleState ? "^" : "v");
		}
	}

	public void Start() {
		Hud = GameObject.Find ("Hud");

		toggleButton = GameObject.Find ("ToggleButton");
		toggleState = false;

		steeringWheel = GameObject.Find ("SteeringWheel");
		steeringWheel.SetActive (false);
	}

	public void HudToggleButtonClicked(string name) {
		toggleState = !toggleState;
	}

	public void Update()
	{
		if (timer >= 0) {
			timer += Time.deltaTime;
			if (timer > 3) {
				timer = -1;
				HudToggleButtonClicked ("");
			}
		}
	}
}
