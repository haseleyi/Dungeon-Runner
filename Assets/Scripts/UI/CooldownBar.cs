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

	public void Cooldown(float cooldown) {
//		print ("Cooldown bar method called!");
//		bar.gameObject.SetActive (false);
		Vector3 scale = bar.transform.localScale;
		scale.x = 0;
		bar.transform.localScale = scale;
		StartCoroutine (CooldownCoroutine (cooldown));
	}

	IEnumerator CooldownCoroutine(float cooldown) {
		float index = 0;
		while (index < cooldown) {
			Vector3 scale = bar.transform.localScale;
			scale.x = index;
			bar.transform.localScale = scale;
			index += Time.deltaTime;
			yield return null;
		}
	}

//	if (healthSlider == null)
//		return;
//	float relativeScale = (float)lives / (float)maxLives;
//	Vector3 scale = healthSlider.transform.localScale;
//	scale.x = relativeScale;
//	healthSlider.transform.localScale = scale;
}
