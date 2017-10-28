using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Environment button is a type of MainMenuButton.
/// </summary>
public class EnvironmentButton : MainMenuButton {

	private MaterialUI.ScreenView buttonView;
	private Toggle toggle;


	public override void Awake () {
		base.Awake();
		//The way this reference is obtained is likely to be changed in the future
		buttonView = transform.parent.parent.parent.parent.parent.GetComponentInChildren<MaterialUI.ScreenView> ();
		toggle = GetComponent<Toggle> ();
	}

	/// <summary>
	/// Override of clicked. sets the environment name and goes to the next buttonview Screen
	/// </summary>
	public override void Clicked () {
		manager.SetEnvironmentName (this,toggle.isOn);
		if(toggle.isOn){
			buttonView.Transition (1);
		}else{
			buttonView.Transition (0);
		}
		EventSystem.current.SetSelectedGameObject (null);
	}

}
