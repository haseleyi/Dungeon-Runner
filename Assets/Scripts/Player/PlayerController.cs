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
		body = GetComponent<Rigidbody2D> ();
		trans = transform;
		trans.position = new Vector2 (0, LaneManager.instance.laneLocations [lane]);
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
		
	}

	void Ability () {
		
	}

	void SwitchLanes (float verticalInput) {
		if (verticalInput > 0 && lane < LaneManager.instance.laneLocations.Capacity - 1) {
			lane += 1;
		} else if (verticalInput < 0 && lane > 0) {
			lane -= 1;
		}

		trans.position = new Vector2(trans.position.x, LaneManager.instance.laneLocations [lane]);
	}

	void OnCollisionEnter2D (Collision2D other) {
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
		} else if (other.gameObject.tag == "cleric") {
		
		}
	}

	void Die () {
	}
}
