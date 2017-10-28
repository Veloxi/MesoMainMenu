using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CompanyButtonVariables {
	public string title;
	public string subtitle;
	public string[] dinosaurs;
	public string money;
	public string description;
	public Sprite background;
	public Color bgColor = Color.white;
	public float bgImageScaleMulti = 1f;
	public Vector2 bgImageOffset;
}

public class CompanyScreen : ButtonScreen {

	public GameObject buttonPrefab;
	public Transform slot;
	public MaterialUI.ScreenView buttonScreen;
	public CompanyButtonVariables[] companies;

	void OnEnable(){
		MenuManager.ResetCompanyToggles ();
	}

	/// <summary>
	/// Spawns the buttons within this screen in their appropriate slots
	/// </summary>
	protected override void SpawnButtons(){
		CompanyButton[] companyButtons = new CompanyButton[companies.Length];
		for(int i = 0; i < companies.Length; i++){
			CompanyButton button = Instantiate (buttonPrefab, slot).GetComponent<CompanyButton>();
			MenuManager.companyToggles.Add (button.GetComponent<Toggle> ());
			RectTransform rect = button.GetComponent<RectTransform> ();
			rect.localPosition = Vector2.zero;
			button.buttonVariables.title = companies[i].title;
			button.buttonVariables.subtitle = companies [i].subtitle;
			button.buttonVariables.description = companies [i].description;
			button.buttonVariables.background = companies [i].background;
			string dinos = "";
			foreach(string dinosaur in companies[i].dinosaurs){
				dinos += dinosaur+"\n";
			}
			button.dinosaurs = dinos;
			button.money = companies [i].money;
			button.buttonVariables.bgColor = companies [i].bgColor;
			button.buttonVariables.bgImageOffset = companies [i].bgImageOffset;
			button.buttonVariables.bgImageScaleMulti = companies [i].bgImageScaleMulti;
			button.UpdateButton ();
			companyButtons [i] = button;
		}
		SpawnTogglesHorizontalScroll (companyButtons, slot);
	}
}
