using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public bool upgraded;
	
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = transform.right * speed;
		if (transform.position.x > -1 * LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
	}
}
