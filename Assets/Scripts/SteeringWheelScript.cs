using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SteeringWheelScript : MonoBehaviour {

	private GameObject toggleButton;
	private GameObject steeringWheel;
	private GameObject Hud;

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
	}

	public void HudToggleButtonClicked(string name) {
		toggleState = !toggleState;
	}

	public void Update()
	{
	}
}
