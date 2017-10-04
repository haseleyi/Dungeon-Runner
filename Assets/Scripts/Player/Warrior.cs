using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerClass {

	public override string title {get; protected set;}
	public float shieldDuration;

	void Start() {
		title = "Warrior";
		canAbility1 = true;
	}
		

	override public void Ability1 () {
		// Do attack stuff
		if (canAbility1) {
			SoundManager.instance.swipe.Play ();
			AnimatorController.instance.UseAbility ();
			Vector2 firePosition = PlayerController.instance.GetPlayerPosition();
			firePosition.x += 0.5f;
			firePosition.y += 0.5f;
			Debug.DrawLine (firePosition, new Vector3 (firePosition.x + 2, firePosition.y), Color.red, 2);
			RaycastHit2D hit = Physics2D.Raycast (firePosition, Vector3.right, 2);

			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
				if (upgraded) {
					hit.collider.GetComponent<Enemy> ().Damage (8);
				} else {
					hit.collider.GetComponent<Enemy> ().Damage (4);
				}
			} else if (hit.collider != null && hit.collider.gameObject.tag == "Boulder") {
				Destroy (hit.collider.gameObject);
			}

			if (upgraded) {
				StartCoroutine(ShieldCoroutine());
			}

			// Disallow attacking for the duration of the cooldown
			canAbility1 = false;
			StartCoroutine(Cooldown1Coroutine ());
		}
	}

	IEnumerator ShieldCoroutine (){
		isInvulnerable = true;
		yield return new WaitForSeconds (shieldDuration);
		isInvulnerable = false;
	}
}
