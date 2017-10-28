using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// This script sets the selected game object of the current event system to this object when this object is enabled.
/// </summary>
public class OnEnableSetFocusHere : MonoBehaviour {

	void OnEnable () {
		EventSystem.current.SetSelectedGameObject (gameObject);
		StartCoroutine (HighlightThis ());
	}
	IEnumerator HighlightThis (){
		EventSystem.current.SetSelectedGameObject (null);
		yield return new WaitForEndOfFrame ();
		EventSystem.current.SetSelectedGameObject (gameObject);
	}
}
