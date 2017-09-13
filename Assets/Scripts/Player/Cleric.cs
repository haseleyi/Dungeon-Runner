using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : PlayerClass {

	void FixedUpdate () {

	}

	override public void Attack () {
		// Do attack stuff
		if (canAttack) {

		}

		// Disallow attacking for the duration of the cooldown
		canAttack = false;
		WaitForAttack ();
	}

	override public void Ability () {
		// Do ability stuff
		if (canAbility) {

		}

		// Disallow attacking for the duration of the cooldown
		canAbility = false;
		WaitForAbility ();
	}
}
