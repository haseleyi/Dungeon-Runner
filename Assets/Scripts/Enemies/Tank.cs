using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy {

	protected override void Die () {
		base.Die ();
		ScoreManager.instance.tanksDefeated++;
	}
}
