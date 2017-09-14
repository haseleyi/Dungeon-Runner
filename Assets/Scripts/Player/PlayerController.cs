using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	public float classDuration = 3;
	public int startLane = 2;
	public float xInitial = -10;

	int lane;
	Rigidbody2D body;
	PlayerClass currentClass;
	public static PlayerController instance;

	void Start () {
		instance = this;
		lane = startLane;
		body = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (xInitial, LaneManager.instance.laneLocations [lane]);
		gameObject.AddComponent<Warrior>();
		gameObject.AddComponent<Mage>();
		gameObject.AddComponent<Ranger>();
		gameObject.AddComponent<Cleric>();
		gameObject.AddComponent<Thief>();
		gameObject.AddComponent<PlayerClass>();

		// For testing purposes (in the actual code, Mage should be PlayerClass)
		currentClass = GetComponent<Mage> ();
	}

	// Using Update here instead of FixedUpdate because it makes for more responsive lane switching
	void Update () {
		MoveLeftRight ();
		SwitchLanes ();
		if (Input.GetKeyDown("j")) {
			currentClass.Attack();
		}
		if (Input.GetKeyDown ("k")) {
			currentClass.Ability ();
		}
//		print (currentClass.title);
	}

	public void MoveLeftRight () {
		Vector2 moveVel = body.velocity;
		moveVel.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
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
			Destroy (other.gameObject);
			ScoreManager.instance.AddCoins (1);
		} else if (other.gameObject.tag == "Warrior") {
			Destroy (other.gameObject);
			currentClass = gameObject.GetComponent<Warrior> ();
			StartCoroutine(ClassTimer ());
			// Update sprite
		} else if (other.gameObject.tag == "Ranger") {
			Destroy (other.gameObject);
			currentClass = gameObject.GetComponent<Ranger> ();
			StartCoroutine(ClassTimer ());
			// Update sprite
		} else if (other.gameObject.tag == "Mage") {
			Destroy (other.gameObject);
			currentClass = gameObject.GetComponent<Mage> ();
			StartCoroutine(ClassTimer ());
			// Update sprite
		} else if (other.gameObject.tag == "Thief") {
			Destroy (other.gameObject);
			currentClass = gameObject.GetComponent<Thief> ();
			StartCoroutine(ClassTimer ());
			// Update sprite
		} else if (other.gameObject.tag == "Cleric") {
			Destroy(other.gameObject);
			currentClass = gameObject.GetComponent<Cleric> ();
			StartCoroutine(ClassTimer ());
			// Update sprite
		}
	}

	IEnumerator ClassTimer () {
		yield return new WaitForSeconds (classDuration);
		currentClass = gameObject.GetComponent<PlayerClass> ();
	}

	void Die () {
		// Display death screen
		Destroy (gameObject);
	}
}
