using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : PlayerClass {

	public override string title {get; protected set;}

	void Start() {
		title = "Ranger";
		canAttack = true;
		canAbility = true;
	}

	override public void Attack () {
		// Do attack stuff
		if (canAttack) {

		}

		// Disallow attacking for the duration of the cooldown
		canAttack = false;
		WaitForAttackCoroutine ();
	}

	override public void Ability () {
		// Do ability stuff
		if (canAbility) {

		}

		// Disallow attacking for the duration of the cooldown
		canAbility = false;
		WaitForAbilityCoroutine ();
	}
}
