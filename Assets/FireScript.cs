using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
	private GameObject FireEffect;
	private GameObject Flamethrower;

	// Use this for initialization
	void Start () {
		FireEffect = GameObject.Find ("FireEffect");
		FireEffect.SetActive (false);

		Flamethrower = GameObject.Find ("Afterburner");
		Flamethrower.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonDownClicked(string name) {
		Flamethrower.SetActive (true);
		FireEffect.SetActive (true);
		FireEffect.GetComponent<ParticleSystem> ().Clear ();
		FireEffect.GetComponent<ParticleSystem> ().Play ();
		Flamethrower.GetComponent<ParticleSystem> ().Clear ();
		Flamethrower.GetComponent<ParticleSystem> ().Play ();
	}

	public void ButtonUpClicked(string name) {
		Flamethrower.SetActive (false);
		FireEffect.SetActive (false);
		FireEffect.GetComponent<ParticleSystem> ().Stop ();
		Flamethrower.GetComponent<ParticleSystem> ().Stop ();
		FireEffect.GetComponent<ParticleSystem> ().Clear ();
		Flamethrower.GetComponent<ParticleSystem> ().Clear ();
	}
}
