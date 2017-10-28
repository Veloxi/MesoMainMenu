using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Should be attached to the parent object that the dinosaur will spawn as a child of.
/// </summary>
public class LoadBackgroundDinosaur : MonoBehaviour {

	[SerializeField]
	private string path = "dinosaurs";
	private GameObject dinosaur;

	void Awake () {
		GameObject[] dinosaurs = Resources.LoadAll<GameObject>(path);
		GameObject dinosaur = Instantiate (dinosaurs [Random.Range (0, dinosaurs.Length)], transform);
		dinosaur.transform.localPosition = Vector3.zero;
	}
}
