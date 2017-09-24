using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

	public float arrowCooldown;
	public GameObject arrowPrefab;

	bool canFire = true;

	void Start() {
		arrowPrefab.gameObject.GetComponent<Arrow> ().speed = -10;
	}

	protected override void FixedUpdate () {
		if (canFire) {
			Vector2 firePosition = transform.position;
			firePosition.y ++;
			Instantiate(arrowPrefab, firePosition, Quaternion.AngleAxis(90, Vector3.forward));

			// Disallow attacking for the duration of the cooldown
			canFire = false;
			StartCoroutine(ArrowCooldown ());
		}
	}


	protected override void Die () {
		base.Die ();
		ScoreManager.instance.archersDefeated++;
	}

	IEnumerator ArrowCooldown () {
		yield return new WaitForSeconds (arrowCooldown);
		canFire = true;
	}
}
