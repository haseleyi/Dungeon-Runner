using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

	public static AnimatorController instance;
	Animator anim;

	// Use this for initialization
	void Start () {
		instance = this;
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateSpeed (float currentSpeed) {
		anim.SetFloat ("Speed", currentSpeed);
		//Debug.Log (currentSpeed);
	}
}
