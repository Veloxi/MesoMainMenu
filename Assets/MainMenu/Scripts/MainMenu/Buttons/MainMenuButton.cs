using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonTypes{
	None = 0,
	NormalButton = 1,
	WideButton = 2,
	TallButton = 3,
}

public enum ButtonEventTypes{
	GoToScreen,
	GoToNewScene
}

[System.Serializable]
public class ButtonVariables {
	public ButtonTypes type;				//Primarily used for spawners. None is fine if a button is custom
	public string title;
	public string subtitle;
	public string description;
	public Sprite background;
	public Color bgColor = Color.white;
	public float bgImageScaleMulti = 1f;
	public Vector2 bgImageOffset;
	public ButtonEventTypes onClick;		//Determines what a SPAWNED button does when it is clicked
	public int nextScreen;					//Next screen IF the onClick event type is set to GoToScreen
	public string sceneToLoad;				//Scene that will load IF onClick is set to GoToNewScene
}

/// <summary>
/// A simple class to handle the variables of each button so that they can be edited in one place
/// </summary>
public class MainMenuButton : MonoBehaviour {

	public ButtonVariables buttonVariables;

	protected Text[] texts;
	protected MenuManager manager;
	protected RectTransform rect;
	[SerializeField]
	protected Image image;

	public virtual void Awake () {
		manager = MenuManager.instance;
		texts = GetComponentsInChildren<Text> ();
		rect = GetComponent<RectTransform> ();
		UpdateButton ();
		StartCoroutine (CenterPivot ());
	}


	/// <summary>
	/// Centers the pivot of this object's rect transform (or ensures that it is centered). 
	/// 	Moves the object so that the position
	/// 	does not change when the pivot does.
	/// Coroutine required. Objects to not have scale on their first frame.
	/// </summary>
	IEnumerator CenterPivot(){
		yield return new WaitForEndOfFrame ();
		Vector2 newPivot = Vector2.one * 0.5f;
		Vector2 size = rect.rect.size;
		Vector2 deltaPivot = rect.pivot - newPivot;
		Vector3 deltaPosition = new Vector3 (deltaPivot.x * size.x, deltaPivot.y * size.y);
		rect.pivot = newPivot;
		rect.localPosition -= deltaPosition;
	}


	/// <summary>Updates components of this button with the strings and sprite stored in this script. 
	/// 	must be called after setting the image or strings manually for changes to show up on the button.
	/// </summary>
	public virtual void UpdateButton(){
		string[] strs = {buttonVariables.title, buttonVariables.subtitle, buttonVariables.description};
		UpdateText (strs);
		StartCoroutine (SetImage ());
	}

	/// <summary>
	/// Sets the text objects to the correct inputed strings. Called by UpdateButton()
	/// </summary>
	protected virtual void UpdateText(string[] strs){
		buttonVariables.title = strs [0];
		buttonVariables.subtitle = strs [1];
		buttonVariables.description = strs [2];
		for(int i = 0; i < strs.Length; i++){
			if(texts.Length > i){
				texts [i].text = strs [i];
			}
		}
	}

	/// <summary>
	/// Updates the image with the appropriate background. Called by UpdateButton()
	/// </summary>
	IEnumerator SetImage(){
		yield return new WaitForEndOfFrame ();
		image.color = buttonVariables.bgColor;
		image.rectTransform.anchoredPosition = buttonVariables.bgImageOffset;
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 
			rect.rect.width * buttonVariables.bgImageScaleMulti);
		image.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 
			rect.rect.height * buttonVariables.bgImageScaleMulti);
		image.sprite = buttonVariables.background;
	}
		
	/// <summary>
	/// General Main Menu Button "on clicked" behavior. updates the main menu manager, and makes
	/// 	sure nothing is selected after you have clicked.
	/// </summary>
	public virtual void Clicked(){
		EventSystem.current.SetSelectedGameObject (null);
		if(buttonVariables.onClick == ButtonEventTypes.GoToNewScene){
			SceneManager.LoadScene (buttonVariables.sceneToLoad);
		}else if(buttonVariables.onClick == ButtonEventTypes.GoToScreen){
			manager.UpdatePath (buttonVariables.title);
			manager.GoToScreen (buttonVariables.nextScreen);
		}
	}

}
