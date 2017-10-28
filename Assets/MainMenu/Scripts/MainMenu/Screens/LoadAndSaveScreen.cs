using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script will need to be updated once I have access to how we are loading and saving games.
/// </summary>
public class LoadAndSaveScreen : ButtonScreen {
	
	[SerializeField]
	private Transform startSpot;

	[SerializeField]
	private MainMenuButton[] buttons; 

	[SerializeField]
	private bool saveScreen;


	//note: this is a temporary script that just uses already premade buttons,
	// later I will have to create buttons that match whatever I read in from the games


	/// <summary>
	/// Uses the menu manager to spawn buttons. If this is a save game, it accounts for the extra
	/// 	content width necessary for the new save game option.
	/// </summary>
	protected override void SpawnButtons(){
		float extraContent = 0;
		if(saveScreen){
			extraContent = buttons [buttons.Length - 1].GetComponent<RectTransform> ().rect.width+50f;
		}
		SpawnButtonsHorizontalScroll (buttons, startSpot, extraContent);
	}
}
