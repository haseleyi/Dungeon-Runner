using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float baseSpeed = 2;
	public bool defeatable;
	public float pointValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (-1,0,0) * Time.deltaTime * baseSpeed;
	}
}
