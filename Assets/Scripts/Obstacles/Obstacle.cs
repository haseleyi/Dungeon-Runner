using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float baseSpeed = -2;
	public bool defeatable;
	public float pointValue;
	protected Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (baseSpeed, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x < LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
	}
}
