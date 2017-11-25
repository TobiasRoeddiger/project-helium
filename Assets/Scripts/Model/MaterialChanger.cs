using System;
using UnityEngine;

public static class MaterialChanger
{
	public static void ChangeMaterial(this GameObject gObject, string texture, MaterialSample sample = null) {
		Material newMat = Resources.Load(texture, typeof(Material)) as Material;
		gObject.GetComponent<Renderer>().material = newMat;

		if (sample != null) {
			// TODO: assign physical properties
		}
	}
}

