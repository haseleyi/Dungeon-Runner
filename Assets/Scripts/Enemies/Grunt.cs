using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy {

	protected override void Die () {
		base.Die ();
		ScoreManager.instance.gruntsDefeated++;
	}
}
