using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : Obstacle {

	[SerializeField] Sprite[] sprites;

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, sprites.Length)];
	}
}
