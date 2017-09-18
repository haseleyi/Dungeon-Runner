using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerClass {

	public GameObject fireballPrefab;
	public float fireDelay;
	float nextFire = 0;
	public override string title {get; protected set;}

	void Start() {
		title = "Mage";
		canAttack = true;
		canAbility = true;
	}

	void Update() {
		print ("canAttack: " + canAttack);
	}

	override public void Attack () {
		// Do attack stuff
		if (canAttack && Time.time > nextFire) {
			nextFire = Time.time + fireDelay;
			Vector3 firePosition = PlayerController.instance.transform.position;
			firePosition.y += .5f;
			Instantiate(fireballPrefab, firePosition, Quaternion.identity);
		}

		// Disallow attacking for the duration of the cooldown
		canAttack = false;
		StartCoroutine(WaitForAttackCoroutine ());
		canAttack = true;
	}

	override public void Ability () {
		// Do ability stuff
		if (canAbility) {

		}

		// Disallow attacking for the duration of the cooldown
		canAbility = false;
		StartCoroutine(WaitForAbilityCoroutine ());
	}
}
