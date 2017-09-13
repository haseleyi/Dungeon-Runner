using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 250;
	public float cooldown = 0.5f;
	public float abilityCooldown = 5;
	public string playerClass = "none";
	public float classDuration = 15;
	public int damage;
	public int range;

	float waitForAttack;
	float waitForAbility;
	float classTimeRemaining;
	Transform trans;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		waitForAttack = cooldown;
		waitForAbility = abilityCooldown;
		body = this.GetComponent<Rigidbody2D> ();
		trans = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		waitForAttack -= Time.deltaTime;
		waitForAbility -= Time.deltaTime;
		classTimeRemaining -= Time.deltaTime;
		Move (Input.GetAxisRaw ("Horizontal"));
		SwitchLanes (Input.GetAxisRaw ("Vertical"));

		if (classTimeRemaining <= 0) {
			playerClass = "none";
		}

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
		if (waitForAttack <= 0) {
			if (playerClass == "warrior") {
				// Do warrior stuff
			} else if (playerClass == "ranger") {
				// Do ranger stuff
			} else if (playerClass == "mage") {
				// Do mage stuff
			} else if (playerClass == "thief") {
				// Do thief stuff
			}
		}
	}

	void Ability () {
		if (waitForAbility <= 0) {
			if (playerClass == "warrior") {
				// Do warrior stuff
			} else if (playerClass == "ranger") {
				// Do ranger stuff
			} else if (playerClass == "mage") {
				// Do mage stuff
			} else if (playerClass == "thief") {
				// Do thief stuff
			}
		}
	}

	void SwitchLanes (float verticalInput) {
		Vector2 pos = body.position;
		
		if (verticalInput > 0 && pos.y < 2) {
			pos.y += 2;
		} else if (verticalInput < 0 && pos.y > -4) {
			pos.y -= 2;
		}
		
		body.position = pos;
	}

	void OnCollisionEnter2D (Collider2D other) {
		if (other.gameObject.tag == "enemy") {
			Die ();
		} else if (other.gameObject.tag == "warrior") {
			Destroy (other.gameObject);
			playerClass = "warrior";
			classTimeRemaining = classDuration;
			// Update sprite
		} else if (other.gameObject.tag == "ranger") {
			Destroy (other.gameObject);
			playerClass = "ranger";
			classTimeRemaining = classDuration;
			// Update sprite
		} else if (other.gameObject.tag == "mage") {
			Destroy (other.gameObject);
			playerClass = "mage";
			classTimeRemaining = classDuration;
			// Update sprite
		} else if (other.gameObject.tag == "thief") {
			Destroy (other.gameObject);
			playerClass = "thief";
			classTimeRemaining = classDuration;
			// Update sprite
		}
	}

	void Die () {
	}
}
