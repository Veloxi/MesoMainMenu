using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// My attempt at guessing some things the overwrite save game button would need. 
/// 	I do not have access to how you guys are loading games yet or
/// 	what each load game will have. I will redo this when i get access to 
/// 	that
/// </summary>
public class OverwriteSaveButton : MainMenuButton {

	public string loadGameID;

	//Will be implemented once I know how to save games.
	public void SaveGame(){
		manager.GoToScene ("LoadScreen"); //TEMPORARY - SHOULD BE REPLACED WITH SAVE GAME FUNCTIONALITY
	}

	public override void Clicked(){
		EventSystem.current.SetSelectedGameObject (null);
		SaveGame ();
	}
}
