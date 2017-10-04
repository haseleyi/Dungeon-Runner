using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy {

	protected override void Die () {
		SoundManager.instance.tankDeath.Play ();
		CameraController.ScreenShake (.15f, .3f);
		ScoreManager.instance.IncrementScore(pointValue);
		ScoreManager.instance.tanksDefeated++;
		Destroy (gameObject);
	}
}
