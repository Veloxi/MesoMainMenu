using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A screen is the primary page of the main menu. It contains various types of buttons or toggles that will be
/// 	spawned by something that inherits this class.
/// </summary>
public abstract class ButtonScreen : MonoBehaviour {

	protected MenuManager manager;

	public virtual void Awake () {
		manager = MenuManager.instance;
		SpawnButtons ();
	}
	protected abstract void SpawnButtons ();

	/// <summary>
	/// When given all of the toggles for a company or environment, for example,
	/// 	spawns them all horizontally with 50px in between, starting from the transform of the
	/// 	slot variable. Widens the content of of the scroll rect to match.
	/// </summary>
	/// <param name="buttons">The array of buttons(toggles) to be placed.</param>
	/// <param name="slot">The location that the first button will go.</param>
	/// <param name="extraContentSpace">The amount of extra space added at the end of content, in case anything else
	/// 	may be in the content transform.</param>
	protected void SpawnTogglesHorizontalScroll(MainMenuButton[] buttons, Transform slot, float extraContentSpace = 0f){
		ToggleGroup tGroup = slot.GetComponent<ToggleGroup> ();
		float x = 0;
		for(int i = 0; i < buttons.Length; i++){
			RectTransform rect = buttons[i].GetComponent<RectTransform>();
			rect.GetComponent<Toggle> ().group = tGroup;
			rect.pivot = Vector2.one*0.5f;
			if(x == 0){
				x = rect.rect.width / 2;
			}
			rect.SetParent(slot);
			float y = -rect.rect.height/2;
			rect.anchoredPosition = new Vector2(x, y);
			if(i != buttons.Length-1){
				x += rect.rect.width + 50f;
			}else{
				x += rect.rect.width/2 +120f;
			}
		}
		RectTransform content = slot.transform.parent.GetComponent<RectTransform> ();
		content.sizeDelta = new Vector2 (x+extraContentSpace, content.rect.height);

	}

	/// <summary>
	/// When given all of the buttons for a specific scroll rect within a screen,
	/// 	spawns them all horizontally with 50px in between, starting from the transform of the
	/// 	slot variable. Widens the content of of the scroll rect to match.
	/// </summary>
	/// <param name="buttons">The array of buttons to be placed.</param>
	/// <param name="slot">The location that the first button will go.</param>
	/// <param name="extraContentSpace">The amount of extra space added at the end of content, in case anything else
	/// 	may be in the content transform.</param>
	protected void SpawnButtonsHorizontalScroll(MainMenuButton[] buttons, Transform slot, float extraContentSpace = 0f){
		float x = 0;
		for(int i = 0; i < buttons.Length; i++){
			RectTransform rect = buttons[i].GetComponent<RectTransform>();
			rect.pivot = Vector2.one*0.5f;
			if(x == 0){
				x = rect.rect.width / 2;
			}
			rect.SetParent(slot);
			float y = -rect.rect.height/2;
			rect.anchoredPosition = new Vector2(x, y);
			if(i != buttons.Length-1){
				x += rect.rect.width + 50f;
			}else{
				x += rect.rect.width/2 +120f;
			}
		}
		RectTransform content = slot.transform.parent.GetComponent<RectTransform> ();
		content.sizeDelta = new Vector2 (x+extraContentSpace, content.rect.height);

	}
}
