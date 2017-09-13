using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : PlayerClass {

	void FixedUpdate () {

	}

	void Attack () {
		// Do attack stuff
		if (canAttack) {

		}

		// Disallow attacking for the duration of the cooldown
		canAttack = false;
		WaitForAttack ();
	}

	void Ability () {
		// Do ability stuff
		if (canAbility) {

		}

		// Disallow attacking for the duration of the cooldown
		canAbility = false;
		WaitForAbility ();
	}
}
