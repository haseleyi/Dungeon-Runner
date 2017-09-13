using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float baseSpeed = 2;
	public float runSpeed;
	public bool defeatable;
	public float health;
	public float pointValue;

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		transform.position += new Vector3 (-1,0,0) * Time.deltaTime * (baseSpeed + runSpeed);
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Arrow")) {
			health -= 1;
		} else if (other.CompareTag("Fireball")) {
			health -= 2;
		} else if (other.CompareTag("Sword")) {
			health -= 4;
		} else {
			print ("Something else...");
		}
	}
}
