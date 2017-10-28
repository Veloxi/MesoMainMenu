using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Simple horizontal scroll script.
/// 	Causes the vertical scroll to scroll horizontally in the scroll
/// 	rect that this script is attached to. 
/// </summary>
public class HorizontalScroll : MonoBehaviour {

	public static bool invertScrolling;

	[SerializeField]
	private float sensitivity = 3f;
	[SerializeField]
	private float scrollToSpeed = 10f;

	private Scrollbar scrollbar;
	private float target;

	void Awake () {
		scrollbar = GetComponent<ScrollRect> ().horizontalScrollbar;
	}
	
	void Update () {
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		target += scroll * sensitivity* (scrollbar.size/1f) * (invertScrolling? 1 : -1);
		target = Mathf.Clamp (target, 0f, 1f);
		ScrollTo (target);
	}
		
	/// <summary>
	/// Scrolls to scrollTarget. Lerps to smooth scrolling.
	/// </summary>
	/// <param name="scrollTarget">Scroll target.</param>
	public void ScrollTo(float scrollTarget){
		scrollbar.value = Mathf.Lerp (scrollbar.value, scrollTarget, Time.deltaTime * scrollToSpeed);
	}

}
