using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass {

	public override string title {get; protected set;}

	void Start() {
		title = "Warrior";
		canAbility = true;
	}

	override public void Ability () {
		// Do attack stuff
		if (canAbility) {
			SoundManager.instance.swipe.Play ();
			AnimatorController.instance.UseAbility ();
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			firePosition.x += 0.5f;
			firePosition.y += 0.5f;
			RaycastHit2D hit = Physics2D.Raycast (firePosition, Vector3.right, 3);

			if (hit && hit.collider.gameObject.tag == "Enemy") {
				if (upgraded) {
					hit.collider.GetComponent<Enemy> ().Damage (8);
				} else {
					hit.collider.GetComponent<Enemy> ().Damage (4);
				}
			} else if (hit && hit.collider.gameObject.tag == "Boulder") {
				Destroy (hit.collider.gameObject);
			}

			// Disallow attacking for the duration of the cooldown
			canAbility = false;
			StartCoroutine(CooldownCoroutine ());
		}
	}
}
