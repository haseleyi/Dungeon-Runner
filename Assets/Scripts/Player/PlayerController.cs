﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3;
	public float classDuration;
	public int startLane = 2;
	public float xInitial = -8;

	int lane;
	Rigidbody2D body;
	PlayerClass currentClass;
	public static PlayerController instance;
	AnimatorController animController;

	void Start () {
		instance = this;
		lane = startLane;
		body = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (xInitial, LaneManager.instance.laneLocations [lane]);

		// For testing purposes (in the actual code, this should be PlayerClass)
		currentClass = GetComponent<PlayerClass> ();
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
		if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space)) {
			AnimatorController.instance.UseAbility ();
			currentClass.Ability1();
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			currentClass.Ability2 ();
		}
	}

	public Vector2 GetPlayerPosition() {
		return transform.position;
	}

	void MoveLeftRight () {
		Vector2 moveVel = body.velocity;
		moveVel.x = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
		body.velocity = moveVel;
		//Debug.Log (body.velocity.x);
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

	void OnCollisionEnter2D (Collision2D other) {
		if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Arrow" && other.gameObject.GetComponent<Arrow> ().speed < 0) && !currentClass.isInvulnerable) {
				Die ();
		} else if (other.gameObject.tag == "Coin") {
			Destroy (other.gameObject);
			if (currentClass.title == "Thief") {
				if (currentClass.upgraded) {
					ScoreManager.instance.AddCoins (4);
				} else {
					ScoreManager.instance.AddCoins (2);
				}
			} else {
				ScoreManager.instance.AddCoins (1);
			}
		} else if (other.gameObject.tag == "Warrior") {
			Destroy (other.gameObject);
			StopCoroutine ("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Warrior> ();
			StartCoroutine ("ClassTimerCoroutine");
			// Update sprite
			if (gameObject.GetComponent<Warrior> ().upgraded) {
				AnimatorController.instance.UpdateClass (5);
			} else {
				AnimatorController.instance.UpdateClass (4);
			}
		} else if (other.gameObject.tag == "Ranger") {
			Destroy (other.gameObject);
			StopCoroutine ("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Ranger> ();
			StartCoroutine ("ClassTimerCoroutine");
			AnimatorController.instance.UpdateClass (2);
		} else if (other.gameObject.tag == "Mage") {
			Destroy (other.gameObject);
			StopCoroutine ("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Mage> ();
			StartCoroutine ("ClassTimerCoroutine");
			AnimatorController.instance.UpdateClass (1);
		} else if (other.gameObject.tag == "Thief") {
			Destroy (other.gameObject);
			StopCoroutine ("ClassTimerCoroutine");
			currentClass = gameObject.GetComponent<Thief> ();
			StartCoroutine ("ClassTimerCoroutine");
			AnimatorController.instance.UpdateClass (3);
		}
	}

	IEnumerator ClassTimerCoroutine () {
		HudManager.instance.cooldownBarBack.gameObject.SetActive (true);
		HudManager.instance.cooldownBarFront.gameObject.SetActive (true);
		yield return new WaitForSeconds (classDuration);
		currentClass = gameObject.GetComponent<PlayerClass> ();
		AnimatorController.instance.UpdateClass (0);
		HudManager.instance.cooldownBarBack.gameObject.SetActive (false);
		HudManager.instance.cooldownBarFront.gameObject.SetActive (false);
	}

	void Die () {
		DeathReport.instance.LoadDeathReport();
	}
}
