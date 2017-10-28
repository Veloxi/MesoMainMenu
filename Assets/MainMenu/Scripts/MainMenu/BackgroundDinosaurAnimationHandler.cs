using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the animator on the dinosaur in the background. It randomizes the animation between idle 
/// 	and an idle action. The amount of idle actions must be set.
/// </summary>
public class BackgroundDinosaurAnimationHandler : MonoBehaviour {

	[SerializeField]
	private float averageTimeUntilAction = 5f;
	[SerializeField]
	private float timeUntilActionRandomization = 1f;
	[SerializeField]
	private int amountOfActions = 2;
	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator> ();
		StartCoroutine (PlayAction ());
	}

	IEnumerator PlayAction(){
		float randomBonus = Random.Range (-timeUntilActionRandomization / 2f, timeUntilActionRandomization / 2f);
		yield return new WaitForSeconds (averageTimeUntilAction + randomBonus);
		animator.SetInteger ("Action", Random.Range (0, amountOfActions));
		animator.SetTrigger ("ActionTrigger");
		StartCoroutine (PlayAction ());
	}
}
