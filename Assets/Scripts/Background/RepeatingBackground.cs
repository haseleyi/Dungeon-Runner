using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private SpriteRenderer sprite;
	private float backgroundHorizontalLength;

	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		backgroundHorizontalLength = 17.89f;
	}
	
	void FixedUpdate () {
		if (transform.position.x < -(backgroundHorizontalLength)) {
			RepositionBackground ();
		}
		/*
		else if (transform.position.x < backgroundHorizontalLength) {
			RepositionBackground();
			print (transform.position.x);
			print (backgroundHorizontalLength);
		}
*/
	}

	private void RepositionBackground() {
		Vector2 backgroundOffSet = new Vector2(backgroundHorizontalLength, 0);
		transform.position = (Vector2)transform.position+ backgroundOffSet*2f;
	}

	/*
	private void RepositionBackground2() {
		Vector2 backgroundOffSet = new Vector2(backgroundHorizontalLength, 0);
		transform.position = (Vector2)transform.position - backgroundOffSet;
	}
	*/
	

}
