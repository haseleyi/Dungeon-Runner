using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float baseSpeed = 2;
	public float runSpeed;
	public bool defeatable;
	public float health;
	public float pointValue;
	protected Rigidbody2D body;

	public void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (-1 * (baseSpeed + runSpeed), 0);
	}
	
	public virtual void FixedUpdate () {
		if (transform.position.x < LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		print ("Collided with enemy!");
		if (other.CompareTag("Arrow")) {
			health -= 1;
		} else if (other.CompareTag("Fireball")) {
			health -= 2;
		} else if (other.CompareTag("Sword")) {
			health -= 4;
		} else {
			print ("Something else...");
		}
	}
}
