using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Company button is a type of MainMenuButton.
/// </summary>
public class CompanyButton : MainMenuButton {

	public string dinosaurs;
	public string money;

	private MaterialUI.ScreenView buttonView;
	private Toggle toggle;


	public override void Awake () {
		base.Awake();
		//The way this reference is obtained is likely to be changed in the future
		buttonView = transform.parent.parent.parent.parent.parent.GetComponentInChildren<MaterialUI.ScreenView> ();
		toggle = GetComponent<Toggle> ();
	}

	/// <summary>
	/// Override of SetText. Adds the extra strings that must be set for the Company button
	/// </summary>
	protected override void UpdateText (string[] strs) {
		base.UpdateText (strs);
		texts [3].text = dinosaurs;
		texts [4].text = money;
	}

	/// <summary>
	/// Override of clicked. sets the company name and goes to the next buttonview Screen
	/// </summary>
	public override void Clicked () {
		manager.SetCompanyName (this, toggle.isOn);
		if(toggle.isOn){
			buttonView.Transition (1);
		}else{
			buttonView.Transition (0);
		}
		EventSystem.current.SetSelectedGameObject (null);
	}

}
