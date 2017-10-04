using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerClass {

	public GameObject fireballPrefab;
	public override string title {get; protected set;}

	void Start() {
		title = "Mage";
		canAbility = true;
	}

	override public void Ability () {
		// Do attack stuff
		if (canAbility) {
			SoundManager.instance.fireball.Play ();
			AnimatorController.instance.UseAbility ();
			if (upgraded) {
				Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
				firePosition.y += .5f;
				Instantiate(fireballPrefab, firePosition, Quaternion.identity);
			}
			StartCoroutine (ShotCoroutine ());

			// Disallow attacking for the duration of the cooldown
			canAbility = false;
			StartCoroutine(Cooldown1Coroutine ());
		}
	}

	IEnumerator ShotCoroutine() {
		yield return new WaitForSeconds (.2f);
		Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
		firePosition.y += .5f;
		Instantiate(fireballPrefab, firePosition, Quaternion.identity);
	}
}
