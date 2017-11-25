using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SteeringWheelScript : MonoBehaviour {

	private GameObject toggleButton;
	private GameObject steeringWheel;
	private GameObject Hud;
	private GameObject Cube;

	private Mesh InitialSteeringWheelMesh;

	bool pressingFireBall = false;

	private bool infoToggleState;

	private bool _toggleState;
	public bool toggleState {
		get {
			return _toggleState;
		}
		set {
			_toggleState = value;
			Hud.SetActive (_toggleState);
			toggleButton.GetComponentInChildren<Text>().text = (_toggleState ? "▼" : "▲");
		}
	}

	public void Start() {
		Hud = GameObject.Find ("Hud");

		toggleButton = GameObject.Find ("ToggleButton");
		toggleState = false;

		steeringWheel = GameObject.Find ("SteeringWheel");
		Cube = GameObject.Find ("Cube");
		Cube.GetComponent<Rigidbody> ().useGravity = false;

		InitialSteeringWheelMesh = steeringWheel.GetComponent<MeshFilter> ().mesh;

	}

	public void HudToggleButtonClicked(string name) {
		toggleState = !toggleState;
	}

	public void InfoToggleButtonClicked(string name) {
		infoToggleState = !infoToggleState;
		if (infoToggleState) {
			SceneManager.LoadScene ("infoMenue", LoadSceneMode.Additive);
		} else {
			Destroy(GameObject.Find ("infoWrapper"));
		}
	}

	public void Physic_Btn_1_Clicked(string name) {	

		var r = (float) steeringWheel.GetComponent<Renderer> ().bounds.size[2] / 2;
		var rand = ((float) UnityEngine.Random.Range (0, 360)) / 360 * Math.PI * 2;

		float x = (float) (steeringWheel.transform.position.x + Math.Cos(rand) * r);
		float y = (float) 5f;
		float z = (float) (steeringWheel.transform.position.z + Math.Sin(rand) * r);

		//float x = (float) steeringWheel.transform.position.x;
     	//float y = (float) 5f;
		//float z = (float) steeringWheel.transform.position.z;
		var newCube = Instantiate (Cube, new Vector3(x, y ,z), Cube.transform.rotation);
		
		newCube.GetComponent<Rigidbody> ().useGravity = true;
		Destroy (newCube, 6f);
	}

	public void Physic_Btn_2_Clicked(string name) {
		pressingFireBall = true;
	}

	public void Physic_Btn_3_Clicked(string name) {

	}

	public void Material_Btn_1_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("Elastoform", MaterialSample.ElastofoamI_133);
		GameObject.Find ("SteeringWheel").GetComponent<MeshFilter> ().mesh = InitialSteeringWheelMesh;
	}

	public void Material_Btn_2_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("Metallic", MaterialSample.Aluminum_5052);
		GameObject.Find ("SteeringWheel").GetComponent<MeshFilter> ().mesh = InitialSteeringWheelMesh;
	}

	public void Material_Btn_3_Clicked(string name) {
		GameObject.Find ("SteeringWheel").ChangeMaterial ("gruen", MaterialSample.UltradurB_4300);
		GameObject.Find ("SteeringWheel").GetComponent<MeshFilter> ().mesh = InitialSteeringWheelMesh;
	}

	public void Update()
	{

	}
}
