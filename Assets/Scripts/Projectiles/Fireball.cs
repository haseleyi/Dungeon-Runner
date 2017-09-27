using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	public bool upgraded;

	Rigidbody2D body;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = transform.right * speed;
		if (transform.position.x > -1 * LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
	}
}
