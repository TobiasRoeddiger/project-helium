using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SteeringWheelScript : MonoBehaviour {

	private GameObject toggleButton;
	private GameObject steeringWheel;
	private GameObject Hud;

	private int _barStep = 2;
	private int _barGoal = 100;
	private int _barLocation = 102;
	private bool _toggleState;
	public bool toggleState {
		get {
			return _toggleState;
		}
		set {
			_toggleState = value;
			Hud.SetActive (_toggleState);
			//_barGoal = _toggleState ? 206 : 100;
			toggleButton.GetComponentInChildren<Text>().text = (_toggleState ? "v" : "^");
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
		// Move bottom bar if necessary
		//if (_barLocation != _barGoal) {
		//	_barLocation = _barLocation + (_barLocation < _barGoal ? 1 : -1) * _barStep;
		//	foreach (Transform child in Hud.transform)
		//		child.position = new Vector3(child.position.x, _barLocation, child.position.z);
		//	toggleButton.GetComponentInChildren<Text> ().text = _barLocation;
		//}
	}
}
