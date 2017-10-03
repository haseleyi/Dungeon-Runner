using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : PlayerClass {

	public override string title {get; protected set;}

	void Start() {
		title = "Thief";
		canAbility1 = true;
		canAbility2 = true;
		upgraded = false;
	}

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			Debug.Log ("attacked");
			StartCoroutine (SwipeSoundCoroutine ());
			AnimatorController.instance.UseAbility ();
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			RaycastHit2D hit = Physics2D.Raycast (firePosition, Vector2.right, 1);
			firePosition.x += 0.5f;
			firePosition.y += 0.5f;
			if (hit != null && hit.collider.gameObject.tag == "Enemy") {
				hit.collider.gameObject.GetComponent<Enemy> ().Damage (4);
			}
			// Disallow attacking for the duration of the cooldown
			canAbility1 = false;
			StartCoroutine(Cooldown1Coroutine ());
		}
	}

	IEnumerator SwipeSoundCoroutine() {
		yield return new WaitForSeconds (.1f);
		SoundManager.instance.swipe.Play ();
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
