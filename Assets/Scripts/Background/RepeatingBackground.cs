using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private SpriteRenderer sprite;
	private float backgroundHorizontalLength;

	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		backgroundHorizontalLength = sprite.size.x;
	}
	
	void FixedUpdate () {
		if (transform.position.x < -backgroundHorizontalLength) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground() {
		Vector2 backgroundOffSet = new Vector2(backgroundHorizontalLength * 2f, 0);
		transform.position = (Vector2) transform.position + backgroundOffSet;
	}
}
