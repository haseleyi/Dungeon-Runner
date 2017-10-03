using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass {

	public override string title {get; protected set;}
	public float shieldDuration = 0.5f;

	void Start() {
		title = "Warrior";
		canAbility1 = true;
		canAbility2 = true;
		upgraded = false;
	}
		

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			AnimatorController.instance.UseAbility ();
			print ("attack!");
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			firePosition.x += 0.5f;
			firePosition.y += 0.5f;
			Debug.DrawLine (firePosition, new Vector3 (firePosition.x + 2, firePosition.y), Color.red, 2);
			RaycastHit2D hit = Physics2D.Raycast (firePosition, Vector3.right, 2);

			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
				hit.collider.GetComponent<Enemy> ().Damage (4);
			}
		}

		// Disallow attacking for the duration of the cooldown
		canAbility1 = false;
		StartCoroutine(Cooldown1Coroutine ());
	}

	override public void Ability2 () {
		// Do ability stuff
		if (upgraded && canAbility2) {
			isInvulnerable = true;
			canAbility2 = false;
			print ("shield!");
			StartCoroutine (ShieldCoroutine ());
		}

		// Disallow attacking for the duration of the cooldown
		canAbility2 = false;
		StartCoroutine(Cooldown2Coroutine ());
	}

	IEnumerator ShieldCoroutine (){
		yield return new WaitForSeconds (shieldDuration);
		isInvulnerable = false;
		StartCoroutine (Cooldown2Coroutine ());
	}
}
