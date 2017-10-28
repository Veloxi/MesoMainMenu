using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Simple script that sets the text of a main menu path when it is enabled.
/// </summary>
public class MainMenuPath : MonoBehaviour {
	void OnEnable () {
		GetComponent<Text>().text = MenuManager.GetLastPath ();
	}
}
