using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	public float classDuration = 10;
	public int startLane = 2;
	public float xInitial = -8;

	int lane;
	Rigidbody2D body;
	PlayerClass currentClass;
	public static PlayerController instance;

	void Start () {
		instance = this;
		lane = startLane;
		body = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (xInitial, LaneManager.instance.laneLocations [lane]);

		// For testing purposes (in the actual code, this should be PlayerClass)
		currentClass = GetComponent<Ranger> ();
	}

	// Using Update here instead of FixedUpdate because it makes for more responsive lane switching
	void Update () {
		MoveLeftRight ();
		SwitchLanes ();
		if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space)) {
			currentClass.Ability1();
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			currentClass.Ability2 ();
		}
	}

	public Vector2 GetPlayerPosition() {
		return transform.position;
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
			StopCoroutine ("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Warrior> ();
			StartCoroutine("ClassTimerCoroutine");
			// Update sprite
		} else if (other.gameObject.tag == "Ranger") {
			Destroy (other.gameObject);
			StopCoroutine("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Ranger> ();
			StartCoroutine("ClassTimerCoroutine");
			// Update sprite
		} else if (other.gameObject.tag == "Mage") {
			Destroy (other.gameObject);
			StopCoroutine("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Mage> ();
			StartCoroutine("ClassTimerCoroutine");
			// Update sprite
		} else if (other.gameObject.tag == "Thief") {
			Destroy (other.gameObject);
			StopCoroutine("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Thief> ();
			StartCoroutine("ClassTimerCoroutine");
			// Update sprite
		} else if (other.gameObject.tag == "Cleric") {
			Destroy(other.gameObject);
			StopCoroutine("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Cleric> ();
			StartCoroutine("ClassTimerCoroutine");
			// Update sprite
		}
	}

	IEnumerator ClassTimerCoroutine () {
		yield return new WaitForSeconds (classDuration);
		currentClass = gameObject.GetComponent<PlayerClass> ();
	}

	void Die () {
		// Display death screen
		DeathReport.instance.LoadDeathReport();
	}
}