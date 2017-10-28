using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple script that sets the text component's text to the current date.
/// </summary>
public class SetTextToDay : MonoBehaviour {
	void Awake () {
		GetComponent<Text>().text = MenuManager.CurrentDate().ToUpper();
	}
}
