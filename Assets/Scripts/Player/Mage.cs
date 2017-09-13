using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : PlayerClass {

	public GameObject fireballPrefab;
	public Transform shotSpawn;

	public float bulletSpeed;
	public float fireRate;
	private float nextFire = 0;

	override public void Attack () {
		// Do attack stuff
		if (canAttack && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(fireballPrefab, shotSpawn.position, Quaternion.identity);
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
