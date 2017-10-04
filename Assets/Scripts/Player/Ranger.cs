using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : PlayerClass {

	public GameObject arrowPrefab;
	public override string title {get; protected set;}

	void Start() {
		title = "Ranger";
		canAbility = true;
	}

	override public void Ability () {
		// Do attack stuff
		if (canAbility) {
			AnimatorController.instance.UseAbility ();
			StartCoroutine (ShotCoroutine ());

			// Disallow attacking for the duration of the cooldown
			canAbility = false;
			if (upgraded) {
				cooldown -= .08f;
			}
			StartCoroutine (Cooldown1Coroutine ());
		}
	}

	IEnumerator ShotCoroutine() {
		yield return new WaitForSeconds (.3f);
		SoundManager.instance.arrow.Play ();
		if (upgraded) {
			arrowPrefab.GetComponent<Arrow> ().speed += 5;
		}
		// Upgraded arrows have a piercing effect
		arrowPrefab.GetComponent<Arrow> ().upgraded = upgraded;
		Vector2 firePosition = PlayerController.instance.GetPlayerPosition ();
		firePosition.y += 1.5f;
		Instantiate (arrowPrefab, firePosition, Quaternion.AngleAxis (90, Vector3.back));
	}
}
