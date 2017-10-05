using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	public float classDuration;
	public int startLane = 2;
	public float xInitial = -8;
	public int coinMultiplier = 1;

	int lane;
	Rigidbody2D body;
	public PlayerClass currentClass;
	public static PlayerController instance;

	void Start () {
		instance = this;
		lane = startLane;
		body = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (xInitial, LaneManager.instance.laneLocations [lane]);

		currentClass = GetComponent<NoClass> ();
		HudManager.instance.cooldownBarBack.gameObject.SetActive (false);
		HudManager.instance.cooldownBarFront.gameObject.SetActive (false);
	}

	// Using Update here instead of FixedUpdate because it makes for more responsive lane switching
	void Update () {
		AnimatorController.instance.UpdateSpeed (body.velocity.x);
		if (GameManager.gameState != GameManager.GameState.Paused) {
			MoveLeftRight ();
			SwitchLanes ();
		}
		if (Input.GetKeyDown(KeyCode.J)
			|| Input.GetKeyDown(KeyCode.K)
			|| Input.GetKeyDown(KeyCode.L)
			|| Input.GetKeyDown(KeyCode.Space)) {
			currentClass.Ability();
		}
	}

	public Vector2 GetPlayerPosition() {
		return transform.position;
	}

	void MoveLeftRight () {
		Vector2 moveVel = body.velocity;
		moveVel.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		if (moveVel.x > 0 && transform.position.x >= 8.4f) {
			moveVel.x = 0;
		}
		if (moveVel.x < -2) {
			moveVel.x = -2;
		}
		body.velocity = moveVel;
	}

	void SwitchLanes () {
		if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			&& lane < LaneManager.instance.laneLocations.Count - 1) {
			lane++;
		} else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			&& lane > 0) {
			lane--;
		}
		transform.position = new Vector2(transform.position.x, LaneManager.instance.laneLocations [lane]);
	}

	void NewClass(Collision2D other) {
		Destroy (other.gameObject);
		coinMultiplier = 1;
		SoundManager.instance.drums.Play ();
		StopCoroutine ("ClassTimerCoroutine");
		StartCoroutine ("ClassTimerCoroutine");
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Enemy" || (other.gameObject.tag == "EnemyArrow" && other.gameObject.GetComponent<Arrow> ().speed < 0)) {
			if (currentClass.isInvulnerable) {
				Destroy (other.gameObject);
			} else {
				Die ();
			}
		} else if (other.gameObject.tag == "Coin") {
			Destroy (other.gameObject);
			ScoreManager.instance.AddCoins(coinMultiplier, false);
		} else if (other.gameObject.tag == "Chest") {
			Destroy (other.gameObject);
			ScoreManager.instance.AddCoins (3 * coinMultiplier, true);
		} else if (other.gameObject.tag == "Warrior") {
			NewClass (other);
			currentClass = gameObject.GetComponent<Warrior> ();
			// Update sprite
			if (gameObject.GetComponent<Warrior> ().upgraded) {
				AnimatorController.instance.UpdateClass (5);
			} else {
				AnimatorController.instance.UpdateClass (4);
			}
		} else if (other.gameObject.tag == "Ranger") {
			NewClass (other);
			currentClass = gameObject.GetComponent<Ranger> ();
			AnimatorController.instance.UpdateClass (2);
		} else if (other.gameObject.tag == "Mage") {
			NewClass (other);
			currentClass = gameObject.GetComponent<Mage> ();
			AnimatorController.instance.UpdateClass (1);
		} else if (other.gameObject.tag == "Thief") {
			NewClass (other);
			currentClass = gameObject.GetComponent<Thief> ();
			if (currentClass.upgraded) {
				coinMultiplier = 4;
			} else {
				coinMultiplier = 2;
			}
			AnimatorController.instance.UpdateClass (3);
		}
	}

	IEnumerator ClassTimerCoroutine () {
		HudManager.instance.cooldownBarBack.gameObject.SetActive (true);
		HudManager.instance.cooldownBarFront.gameObject.SetActive (true);
		yield return new WaitForSeconds (classDuration);
		currentClass = gameObject.GetComponent<NoClass> ();
		AnimatorController.instance.UpdateClass (0);
		HudManager.instance.cooldownBarFront.GetComponent<CooldownBar> ().Reset ();
		HudManager.instance.cooldownBarBack.gameObject.SetActive (false);
		HudManager.instance.cooldownBarFront.gameObject.SetActive (false);
		coinMultiplier = 1;
		gameObject.GetComponent<Ranger> ().arrowPrefab.GetComponent<Arrow> ().speed = 10;
		gameObject.GetComponent<Ranger> ().cooldown = 1;
	}

	void Die () {
		SoundManager.instance.track1.Stop ();
		SoundManager.instance.track2.Stop ();
		SoundManager.instance.track3.Stop ();
		DeathReport.instance.LoadDeathReport();
	}
}
