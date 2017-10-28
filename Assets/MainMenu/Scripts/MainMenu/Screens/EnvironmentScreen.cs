using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnvironmentButtonVariables {
	public string title;
	public string subtitle;
	public string description;
	public Sprite background;
	public Color bgColor = Color.white;
	public float bgImageScaleMulti = 1f;
	public Vector2 bgImageOffset;
}

public class EnvironmentScreen : ButtonScreen {

	public GameObject buttonPrefab;
	public Transform slot;
	public MaterialUI.ScreenView buttonScreen;
	public EnvironmentButtonVariables[] environments;

	void OnEnable(){
		MenuManager.ResetEnvironmentToggles ();
	}
	
	/// <summary>
	/// Spawns the buttons within this screen in their appropriate slots
	/// </summary>
	protected override void SpawnButtons(){
		EnvironmentButton[] environmentButtons = new EnvironmentButton[environments.Length];
		for(int i = 0; i < environments.Length; i++){
			EnvironmentButton button = Instantiate (buttonPrefab, slot).GetComponent<EnvironmentButton>();
			MenuManager.environmentToggles.Add (button.GetComponent<Toggle> ());
			RectTransform rect = button.GetComponent<RectTransform> ();
			rect.localPosition = Vector2.zero;
			button.buttonVariables.title = environments[i].title;
			button.buttonVariables.subtitle = environments [i].subtitle;
			button.buttonVariables.description = environments [i].description;
			button.buttonVariables.background = environments [i].background;
			button.buttonVariables.bgColor = environments [i].bgColor;
			button.buttonVariables.bgImageOffset = environments [i].bgImageOffset;
			button.buttonVariables.bgImageScaleMulti = environments [i].bgImageScaleMulti;
			button.UpdateButton ();
			environmentButtons [i] = button;
		}
		SpawnTogglesHorizontalScroll (environmentButtons, slot);
	}
}
