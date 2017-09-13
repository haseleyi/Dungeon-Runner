using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 250;
	public int startLane = 2;

	int lane;
	Transform trans;
	Rigidbody2D body;
	PlayerClass currentClass;

	// Use this for initialization
	void Start () {
		lane = startLane;
		body = this.GetComponent<Rigidbody2D> ();
		trans = this.transform;
		trans.position.y = LaneManager.laneLocations [lane];
		trans.position.x = 0;
		currentClass = null;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move (Input.GetAxisRaw ("Horizontal"));
		SwitchLanes (Input.GetAxisRaw ("Vertical"));

		if (Input.GetButtonDown("J")) {
			Attack();
		}

		if (Input.GetButtonDown ("K")) {
			Ability ();
		}
	}

	public void Move (float horizontalInput) {
		Vector2 moveVel = body.velocity;
		moveVel.x = horizontalInput * speed;
		body.velocity = moveVel;
	}

	void Attack () {
		/* if (waitForAttack <= 0) {
			if (playerClass == "warrior") {
				// Do warrior stuff
			} else if (playerClass == "ranger") {
				// Do ranger stuff
			} else if (playerClass == "mage") {
				// Do mage stuff
			} else if (playerClass == "thief") {
				// Do thief stuff
			}
		} */
	}

	void Ability () {
		/* if (waitForAbility <= 0) {
			if (playerClass == "warrior") {
				// Do warrior stuff
			} else if (playerClass == "ranger") {
				// Do ranger stuff
			} else if (playerClass == "mage") {
				// Do mage stuff
			} else if (playerClass == "thief") {
				// Do thief stuff
			}
		} */
	}

	void SwitchLanes (float verticalInput) {
		if (verticalInput > 0 && lane < LaneManager.laneLocations.Capacity - 1) {
			lane += 1;
		} else if (verticalInput < 0 && lane > 0) {
			lane -= 1;
		}

		body.position.y = LaneManager.laneLocations [lane];
	}

	void OnCollisionEnter2D (Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			Die ();
		} else if (other.gameObject.tag == "warrior") {
			Destroy (other.gameObject);

			// Update sprite
		} else if (other.gameObject.tag == "ranger") {
			Destroy (other.gameObject);

			// Update sprite
		} else if (other.gameObject.tag == "mage") {
			Destroy (other.gameObject);

			// Update sprite
		} else if (other.gameObject.tag == "thief") {
			Destroy (other.gameObject);

			// Update sprite
		}
	}

	void Die () {
	}
}
