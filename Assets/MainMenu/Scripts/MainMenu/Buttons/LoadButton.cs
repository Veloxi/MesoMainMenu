using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// My attempt at guessing some things the Load button would need. 
/// 	I do not have access to how you guys are loading games yet or
/// 	what each load game will have. I will redo this when i get access to 
/// 	that
/// </summary>
public class LoadButton : MainMenuButton {

	public string loadGameDate;
	public string environmentDescription;
	public string loadGameID;
	public Sprite loadGameImage;

	public override void UpdateButton(){
		buttonVariables.subtitle = loadGameDate;
		buttonVariables.description = environmentDescription;
		base.UpdateButton ();
	}

	//Will be implemented once I know how to load games.
	public void LoadGame(){
		manager.GoToScene("LoadScreen"); //TEMPORARY - SHOULD BE REPLACED WITH LOAD GAME FUNCTIONALITY
	}

	public override void Clicked(){
		EventSystem.current.SetSelectedGameObject (null);
		LoadGame ();
	}
}
