using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : PlayerClass {
	public GameObject arrowPrefab;
	public override string title {get; protected set;}

	void Start() {
		title = "Ranger";
		canAttack = true;
		canAbility = true;
	}

	override public void Attack () {
		// Do attack stuff
		if (canAttack) {
			Vector2 firePosition = PlayerController.instance.transform.position;
			firePosition.y ++;
			Instantiate(arrowPrefab, firePosition, Quaternion.AngleAxis(90, Vector3.back));

			// Disallow attacking for the duration of the cooldown
			canAttack = false;
			WaitForAttackCoroutine ();
		}


	}

	override public void Ability () {
		// Do ability stuff
		if (canAbility) {

			// Disallow attacking for the duration of the cooldown
			canAbility = false;
			WaitForAbilityCoroutine ();
		}


	}
}
