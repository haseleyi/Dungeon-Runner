using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

	public float arrowCooldown;
	public GameObject arrowPrefab;

	bool canFire = false;

	void Start() {
		arrowPrefab.gameObject.GetComponent<Arrow> ().speed = -10;
		StartCoroutine (ArrowCooldown (Random.Range (0, 3)));
	}

	protected override void FixedUpdate () {
		if (canFire) {
			Vector2 firePosition = transform.position;
			firePosition.y ++;
			Instantiate(arrowPrefab, firePosition, Quaternion.AngleAxis(90, Vector3.forward));

			// Disallow attacking for the duration of the cooldown
			canFire = false;
			StartCoroutine(ArrowCooldown (arrowCooldown));
		}
	}


	protected override void Die () {
		base.Die ();
		ScoreManager.instance.archersDefeated++;
	}

	IEnumerator ArrowCooldown (float cooldown) {
		yield return new WaitForSeconds (cooldown);
		canFire = true;
	}
}
