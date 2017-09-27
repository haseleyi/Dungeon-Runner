using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public float speed;
	public float gravity;
	public bool upgraded;

	Rigidbody2D body;
	float startY;

	void Start() {
		body = GetComponent<Rigidbody2D> ();
		startY = transform.position.y;
	}


	// Update is called once per frame
	void FixedUpdate () {
		body.velocity = new Vector2 (speed, -gravity);
		if (transform.position.x > -1 * LaneManager.instance.xThreshold || (startY - transform.position.y) > 0.5f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Enemy" && !upgraded) {
			Destroy (gameObject);
		}
	}
}
