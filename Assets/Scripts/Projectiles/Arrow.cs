using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed;

	Rigidbody2D body;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame
	void FixedUpdate () {
		body.velocity = transform.right * speed;
		if (transform.position.x > -1 * LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
	}
}
