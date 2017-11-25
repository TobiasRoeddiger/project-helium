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

	public void Physic_Btn_1_Clicked(string name) {

	}

	public void Physic_Btn_2_Clicked(string name) {

	}

	public void Physic_Btn_3_Clicked(string name) {

	}

	public void Material_Btn_1_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("Elastoform", MaterialSample.ElastofoamI_133);
	}

	public void Material_Btn_2_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("Metallic", MaterialSample.UltradurB_4300);
	}

	public void Material_Btn_3_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("Spotted", MaterialSample.UltradurB_4300);
	}

	public void Update()
	{
	}
}
