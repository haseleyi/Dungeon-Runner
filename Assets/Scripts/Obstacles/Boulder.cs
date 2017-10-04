using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : Obstacle {

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "EnemyArrow") {
			Destroy (other.gameObject);
		}
	}
}
