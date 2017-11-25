using System;
using UnityEngine;
using UnityEditor;

public static class MaterialChanger
{
	public static void ChangeMaterial(this GameObject gObject, string texture, MaterialSample sample = null) {
		Material newMat = (Material) AssetDatabase.LoadAssetAtPath("Assets/Materials/" + texture + ".mat", typeof(Material));

		gObject.GetComponent<Renderer>().material = newMat;

		if (sample != null) {
			gObject.GetComponent<Meshinator>().m_ForceMultiplier = (float) (1 / sample.ElasticModulus) * 300;
		}
	}
}

