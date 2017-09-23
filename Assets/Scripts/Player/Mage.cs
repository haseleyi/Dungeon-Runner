using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerClass {

	public GameObject fireballPrefab;
	public override string title {get; protected set;}

	void Start() {
		title = "Mage";
		canAbility1 = true;
		canAbility2 = true;
		upgraded = false;
	}

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			firePosition.y += .5f;
			Instantiate(fireballPrefab, firePosition, Quaternion.identity);
			if (upgraded) {
				StartCoroutine (SecondShotCoroutine ());
			}

			// Disallow attacking for the duration of the cooldown
			canAbility1 = false;
			StartCoroutine(Cooldown1Coroutine ());
		}
	}

	override public void Ability2 () {
		// Do ability stuff
		if (upgraded && canAbility2) {

			// Disallow ability for the duration of the cooldown
			canAbility2 = false;
			StartCoroutine(Cooldown2Coroutine ());
		}
	}

	IEnumerator SecondShotCoroutine() {
		yield return new WaitForSeconds (.1f);
		Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
		firePosition.y += .5f;
		Instantiate(fireballPrefab, firePosition, Quaternion.identity);
	}
}
