using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	public float speed = 3;

	protected Transform trans;
	protected Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		trans = transform;
		body.velocity = new Vector2 (-speed, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (trans.position.x < -17) {
			Destroy (gameObject);
		}
	}
}