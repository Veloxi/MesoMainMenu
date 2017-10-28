using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// A class that intends to make it easier to create buttons for each screen. These button screens are only
/// 	intended for buttons that go to another screen within this menu, or for those that go to another
/// 	scene. Any other buttons must be created in another way
/// </summary>
public class NormalScreen : ButtonScreen {

	public ButtonVariables[] buttons;


	protected Transform[] slots;

	public override void Awake(){
		slots = new Transform[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			slots [i] = transform.GetChild (i);
		}
		base.Awake ();
	}

	/// <summary>
	/// Spawns the buttons within this screen in their appropriate slots
	/// </summary>
	protected override void SpawnButtons(){
		for(int i = 0; i < slots.Length; i++){
			if((int)(buttons [i].type) == 0) continue;
			MainMenuButton button = Instantiate (manager.buttonTypes [(int)(buttons [i].type)], slots[i]);
			RectTransform rect = button.GetComponent<RectTransform> ();
			rect.localPosition = Vector2.zero;
			button.buttonVariables= buttons [i];
			button.UpdateButton ();
		}
	}
}
