using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : PlayerClass {

	public GameObject arrowPrefab;
	public override string title {get; protected set;}

	void Start() {
		title = "Ranger";
		canAbility1 = true;
	}

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			AnimatorController.instance.UseAbility ();
			StartCoroutine (ShotCoroutine ());

			// Disallow attacking for the duration of the cooldown
			canAbility1 = false;
			StartCoroutine (Cooldown1Coroutine ());
		}
	}

	IEnumerator ShotCoroutine() {
		yield return new WaitForSeconds (.3f);
		SoundManager.instance.arrow.Play ();
		arrowPrefab.GetComponent<Arrow> ().speed = 10;
		// Upgraded arrows have a piercing effect
		arrowPrefab.GetComponent<Arrow> ().upgraded = upgraded;
		Vector2 firePosition = PlayerController.instance.GetPlayerPosition ();
		firePosition.y += 1.5f;
		Instantiate (arrowPrefab, firePosition, Quaternion.AngleAxis (90, Vector3.back));
	}
}
