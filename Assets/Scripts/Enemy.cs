using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float base_speed;
	public float run_speed;
	public bool defeatable;
	public float health;
	public float point_value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (-1,0,0) * Time.deltaTime * (base_speed + run_speed);
	}
}
