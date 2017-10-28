using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Randomizes Dinosaur image from resources. Randomizes text from an array
/// 	Causes the load screne to transition back to main
/// 	menu after 10 seconds.
/// </summary>
public class LoadScreenManager : MonoBehaviour {

	public string dinosaurRenderPath;
	public string[] loadScreenTexts;

	[SerializeField]
	private Image image;
	[SerializeField]
	private Text text;
	private Sprite[] dinosaurRenders;

	void Awake () {
		dinosaurRenders = Resources.LoadAll<Sprite> (dinosaurRenderPath);
		image.sprite = dinosaurRenders [Random.Range (0, dinosaurRenders.Length)];
		text.text = loadScreenTexts [Random.Range (0, loadScreenTexts.Length)];
		Invoke ("LoadMainMenu",4f);
	}
	void LoadMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
}
