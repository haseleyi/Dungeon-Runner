using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

	public float arrowCooldown;
	
	// Update is called once per frame
	override public void FixedUpdate () {
		if (transform.position.x < LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	IEnumerator ArrowCooldown () {
		yield return new WaitForSeconds (0);
	}
}
