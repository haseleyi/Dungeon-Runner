using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour {

	Image bar;

	void Start () {
		bar = GetComponent<Image> ();
	}
	
	void Update () {
		
	}

	public void MyMythod() {
		print ("Method called!");
	}
}
