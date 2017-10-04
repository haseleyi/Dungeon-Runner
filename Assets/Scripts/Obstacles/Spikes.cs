using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	float origY;

	// Update is called once per frame
	void Update () {
		origY = transform.position.y;
		transform.position = Camera.main.ViewportToWorldPoint(new Vector3 (0, 0, 0));
		transform.position = new Vector2 (transform.position.x + 0.25f, origY);
	}
}
