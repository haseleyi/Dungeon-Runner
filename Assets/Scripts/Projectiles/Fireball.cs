using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float speed;
	
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}
}
