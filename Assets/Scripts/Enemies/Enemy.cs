using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float baseSpeed = 2;
	public float runSpeed;
	public bool defeatable;
	public int health;
	public int pointValue;
	protected Rigidbody2D body;

	public void Awake () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (-1 * (baseSpeed + runSpeed), 0);
	}
	
	public virtual void FixedUpdate () {
		if (transform.position.x < LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
		if (health <= 0) {
			ScoreManager.instance.ScoreEnemy (pointValue);
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Arrow") {
			health -= 1;
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Fireball") {
			health -= 2;
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Sword") {
			health -= 4;
		}
	}
}
