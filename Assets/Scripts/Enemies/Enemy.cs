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

	void Awake () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (-1 * (baseSpeed + runSpeed), 0);
	}
	
	protected void Update () {
		if (transform.position.x < LaneManager.instance.xThreshold) {
			Destroy (gameObject);
		}
		if (health <= 0) {
			Die ();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Arrow" && other.gameObject.GetComponent<Arrow> ().speed > 0) {
			health -= 1;
			if (!other.gameObject.GetComponent<Arrow> ().upgraded) {
				Destroy (other.gameObject);
			}
		} else if (other.gameObject.tag == "Fireball") {
			health -= 2;
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Sword") {
			health -= 4;
		}
	}

	protected virtual void Die() {
		ScoreManager.instance.IncrementScore(pointValue);
		Destroy (gameObject);
	}

	public void Damage (int dam) {
		health -= dam;
	}
}
