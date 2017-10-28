using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Simple Splash screen manager. Handles animations and transitions within the splash screen.
/// </summary>
public class SplashScreenManager : MonoBehaviour {

	public float transition1Time = 5f;
	public float transition2Time = 5f;

	public MaterialUI.ScreenView largeLogoScreen;
	public MaterialUI.ScreenView smallLogoScreen;
	public MaterialUI.ScreenView unityLogoScreen;

	void Start () {
		Invoke ("Transition1", 0.1f);
	}
	
	public void Transition1(){
		largeLogoScreen.Transition (1);
		smallLogoScreen.Transition (1);
		unityLogoScreen.Transition (1);
		Invoke ("Transition2", transition1Time);
	}
	public void Transition2(){
		smallLogoScreen.Transition(2);
		largeLogoScreen.gameObject.GetComponent<Animator>().SetTrigger("SecondState");
		Invoke ("Transition3", transition2Time);
	}
	public void Transition3(){
		largeLogoScreen.Transition (0);
		smallLogoScreen.Transition (0);
		unityLogoScreen.Transition (0);
		Invoke ("NextScene", 1f);
	}

	public void NextScene(){
		SceneManager.LoadScene("MainMenu");
	}

}
