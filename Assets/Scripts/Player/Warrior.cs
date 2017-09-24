using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass {

	public override string title {get; protected set;}

	void Start() {
		title = "Warrior";
		canAbility1 = true;
		canAbility2 = true;
		upgraded = false;
	}

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			RaycastHit2D hit = Physics2D.Raycast (firePosition, Vector2.right, 2);
			if (hit != null && hit.collider.gameObject.tag == "Enemy") {
				hit.collider.gameObject.GetComponent<Enemy> ().Damage (4);
			}
		}

		// Disallow attacking for the duration of the cooldown
		canAbility1 = false;
		StartCoroutine(Cooldown1Coroutine ());
	}

	override public void Ability2 () {
		// Do ability stuff
		if (upgraded && canAbility2) {

		}

		// Disallow attacking for the duration of the cooldown
		canAbility2 = false;
		StartCoroutine(Cooldown2Coroutine ());
	}
}
