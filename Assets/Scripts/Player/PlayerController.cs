using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 3;
	public float classDuration = 15;
	public int startLane = 2;
	public float xInitial = -10;

	int lane;
	Rigidbody2D body;
	PlayerClass currentClass;

	void Start () {
		lane = startLane;
		body = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (xInitial, LaneManager.instance.laneLocations [lane]);
		currentClass = new PlayerClass ();
		foreach (float x in LaneManager.instance.laneLocations) {
			print (x);
		}

	}

	void Update () {
		Move (Input.GetAxisRaw ("Horizontal"));
		SwitchLanes ();

		if (Input.GetKeyDown("j")) {
			currentClass.Attack();
		}

		if (Input.GetKeyDown ("k")) {
			currentClass.Ability ();
		}
	}

	public void Move (float horizontalInput) {
		Vector2 moveVel = body.velocity;
		moveVel.x = horizontalInput * speed * Time.deltaTime;
		body.velocity = moveVel;
	}

	void SwitchLanes () {
		if ((Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && lane < LaneManager.instance.laneLocations.Count - 1) {
			lane += 1;
		} else if ((Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) && lane > 0) {
			lane -= 1;
		}

		transform.position = new Vector2(transform.position.x, LaneManager.instance.laneLocations [lane]);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Enemy") {
			Die ();
		} else if (other.gameObject.tag == "Coin") {
			// Do whatever coins do
		} else if (other.gameObject.tag == "Warrior") {
			Destroy (other.gameObject);
			currentClass = new Warrior ();
			ClassTimer ();
			// Update sprite
		} else if (other.gameObject.tag == "Ranger") {
			Destroy (other.gameObject);
			currentClass = new Ranger ();
			ClassTimer ();
			// Update sprite
		} else if (other.gameObject.tag == "Mage") {
			Destroy (other.gameObject);
			currentClass = new Mage ();
			ClassTimer ();
			// Update sprite
		} else if (other.gameObject.tag == "Thief") {
			Destroy (other.gameObject);
			currentClass = new Thief ();
			ClassTimer ();
			// Update sprite
		} else if (other.gameObject.tag == "Cleric") {
			Destroy(other.gameObject);
			currentClass = new Cleric ();
			ClassTimer ();
			// Update sprite
		}
	}

	IEnumerator ClassTimer () {
		yield return new WaitForSeconds (classDuration);
		currentClass = new PlayerClass ();
	}

	void Die () {
		// Display death screen

		Destroy (gameObject);
	}
}
