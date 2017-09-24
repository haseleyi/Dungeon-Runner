using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy {

	public float arrowCooldown;

	IEnumerator ArrowCooldown () {
		yield return new WaitForSeconds (0);
	}

	protected override void Die () {
		base.Die ();
		ScoreManager.instance.archersDefeated++;
	}
}
