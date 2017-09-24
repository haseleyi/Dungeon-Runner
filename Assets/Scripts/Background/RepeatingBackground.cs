﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	//private BoxCollider2D backgroundCollider;
	private SpriteRenderer sprite;
	private float backgroundHorizontalLength;

	// Use this for initialization
	void Start () {
		//backgroundCollider = GetComponent<BoxCollider2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		backgroundHorizontalLength = sprite.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -backgroundHorizontalLength) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground() {
		Vector2 backgroundOffSet = new Vector2(backgroundHorizontalLength * 2f, 0);
		transform.position = (Vector2) transform.position + backgroundOffSet;
	}
}
