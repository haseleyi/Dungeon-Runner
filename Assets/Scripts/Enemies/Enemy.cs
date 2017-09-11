using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float baseSpeed;
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
	}
}
