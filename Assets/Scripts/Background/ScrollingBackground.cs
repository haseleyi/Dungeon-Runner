using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	private Rigidbody2D body;
	public float scrollSpeed;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.velocity = new Vector2 (-scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
