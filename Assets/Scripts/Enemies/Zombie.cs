using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy {

	protected override void Die () {
		base.Die ();
		ScoreManager.instance.gruntsDefeated++;
	}
}
