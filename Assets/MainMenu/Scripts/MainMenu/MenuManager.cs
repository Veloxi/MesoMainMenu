using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The variables that can be set by the player throughout this menu. They are updated as the player
/// 	sets them.
/// </summary>
public struct NewGameVariables{
	public string companyName;
	public string environmentName;
	public bool sandbox;
}

/// <summary>
/// Manager for the main menu. Houses a majority of functions that are called by the "Clicked" function
/// 	of MainMenuButtons, as well as other unique buttons throughout the scene.
/// </summary>
public class MenuManager : MonoBehaviour {

	public static NewGameVariables newGame;

	[SerializeField]
	private MaterialUI.ScreenView buttonScreens;
	[SerializeField]
	private MaterialUI.ScreenView pathAndTitle;

	private Stack<string>previousPaths;
	private Stack<int> screenPath;

	public static MenuManager instance;
	public static List<Toggle> companyToggles;
	public static List<Toggle> environmentToggles;

	[SerializeField]
	public MainMenuButton[] buttonTypes;

	void Awake(){
		screenPath = new Stack<int> ();
		previousPaths = new Stack<string> ();
		previousPaths.Push("");
		instance = GetComponent<MenuManager> ();

		companyToggles = new List<Toggle>();
		environmentToggles = new List<Toggle>();
	}

	/// <summary>
	/// Transitions all necessary screens to a particular screen number
	/// </summary>
	/// <param name="screen">The screen you wish to transition to.</param>
	public void GoToScreen(int screen){
		int current = buttonScreens.currentScreen;
		screenPath.Push (current);
		buttonScreens.Transition (screen);
		pathAndTitle.Transition (screen);
	}

	/// <summary>
	/// Transitions all necessary screens to a particular screen number
	/// </summary>
	/// <param name="screen">the button that contains a variable for the next screen</param>
	public void GoToScreen(MainMenuButton button){
		GoToScreen (button.buttonVariables.nextScreen);
	}

	/// <summary>
	/// Updates previous path stacks with your company selection
	/// </summary>
	public void FinishCompanySelection(){
		screenPath.Push (buttonScreens.currentScreen);
		UpdatePath (newGame.companyName);
	}

	/// <summary>
	/// Updates previous path stacks with your environment selection
	/// </summary>
	public void FinishEnvironmentSelection(){
		screenPath.Push (buttonScreens.currentScreen);
		UpdatePath (newGame.environmentName);
	}

	/// <summary>
	/// Updates the previousPaths stack with the path that must be printed on the next screen.
	/// </summary>
	/// <param name="nameForPath">The name that is being added to the new path.</param>
	public void UpdatePath(string nameForPath){
		int current = buttonScreens.currentScreen;
		previousPaths.Push ( previousPaths.Peek()+ "  /  "+ 
							(nameForPath == "" ? buttonScreens.materialScreen [current].name : nameForPath));
	}

	/// <summary>
	/// Updates the previousPaths stack with the path that must be printed on the next screen.
	/// </summary>
	/// <param name="button">The button whos title will update the path.</param>
	public void UpdatePath(MainMenuButton button){
		UpdatePath (button.buttonVariables.title);
	}

	/// <summary>
	/// Uses an internal stack to go back one screen. Updates Stack
	/// </summary>
	public void GoBackOneScreen(){
		if(previousPaths.Count > 0){
			previousPaths.Pop ();
		}
		if(screenPath.Count > 0){
			int screen = screenPath.Pop ();
			buttonScreens.Transition (screen);
			pathAndTitle.Transition (screen);
		}
	}



	/// <summary>
	/// Sets the name of the company. Updates animations for all company Toggles
	/// </summary>
	/// <param name="button">The current company toggle that has been pressed.</param>
	/// <param name="on">Whether or not the current company toggle has just been
	/// 	turned on or off</param>
	public void SetCompanyName(MainMenuButton button, bool on){
		string name = button.buttonVariables.title;
		newGame.companyName = name;
		foreach(Toggle toggle in companyToggles){
			Animator animator = toggle.GetComponent<Animator> ();
			if(!toggle.isOn){
				animator.SetBool("Disabled", on);
			}else{
				animator.SetBool("Disabled", !on);
			}
			animator.SetTrigger ("Normal");
		}
	}

	/// <summary>
	/// Sets the name of the environment. Updates animations for all environment Toggles
	/// </summary>
	/// <param name="button">The current environment toggle that has been pressed.</param>
	/// <param name="on">Whether or not the environment company toggle has just been
	/// 	turned on or off</param>
	public void SetEnvironmentName(MainMenuButton button, bool on){
		newGame.environmentName = button.buttonVariables.title;
		foreach(Toggle toggle in environmentToggles){
			Animator animator = toggle.GetComponent<Animator> ();
			if(!toggle.isOn){
				animator.SetBool("Disabled", on);
			}else{
				animator.SetBool("Disabled", !on);
			}
			animator.SetTrigger ("Normal");
		}
	}

	/// <summary>
	/// Resets the environment toggles to their default off state.
	/// </summary>
	public static void ResetEnvironmentToggles(){
		foreach(Toggle toggle in environmentToggles){
			Animator animator = toggle.GetComponent<Animator> ();
			toggle.isOn = false;
			animator.SetBool("Disabled", false);
		}
	}
	/// <summary>
	/// Resets the company toggles to their default off state.
	/// </summary>
	public static void ResetCompanyToggles(){
		foreach(Toggle toggle in companyToggles){
			Animator animator = toggle.GetComponent<Animator> ();
			toggle.isOn = false;
			animator.SetBool("Disabled", false);
		}
	}

	/// <summary>
	/// Toggles whether or not a new game would be created in sandbox mode.
	/// </summary>
	public void ToggleSandbox(){
		newGame.sandbox = !newGame.sandbox;
	}

		
	/// <summary>
	/// Gets the most recent menu path string.
	/// </summary>
	/// <returns>The most recent path.</returns>
	public static string GetLastPath(){
		return GetPreviousPaths().Peek ();
	}

	/// <summary>
	/// Gets the previous paths.
	/// </summary>
	/// <returns>The previous paths.</returns>
	private static Stack<string> GetPreviousPaths(){
		return instance.previousPaths;
	}

	/// <summary>
	/// Returns the current date in the correct string format.
	/// </summary>
	/// <returns>The date.</returns>
	public static string CurrentDate(){
		string month;
		switch(System.DateTime.Now.Month)
		{
			case 1:
				month = "January";
				break;
			case 2:
				month = "February";
				break;
			case 3:
				month = "March";
				break;
			case 4:
				month = "April";
				break;
			case 5:
				month = "May";
				break;
			case 6:
				month = "June";
				break;
			case 7:
				month = "July";
				break;
			case 8:
				month = "August";
				break;
			case 9:
				month = "September";
				break;
			case 10:
				month = "October";
				break;
			case 11:
				month = "November";
				break;
			case 12:
				month = "December";
				break;
			default:
				month = "";
				break;
		}
		return System.DateTime.Now.DayOfWeek.ToString () + ", "
		+ month + " " + System.DateTime.Now.Day;
	}

	/// <summary>
	/// Goes to scene based off of scene name.
	/// </summary>
	/// <param name="sceneName">Scene name.</param>
	public void GoToScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	/// <summary>
	/// Goes to scene based off of scene index.
	/// </summary>
	/// <param name="sceneIndex">Scene index.</param>
	public void GoToScene(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void OnAlertTwoCallbacksButtonClicked()
	{
		MaterialUI.DialogManager.ShowAlert(null, 
			() => { Application.Quit(); Debug.Log("Quitting");}, "YES", 
			"Are you sure you want to quit?" , null, 
			() => { Debug.Log("Not Quitting"); }, "NO");
	}

}
