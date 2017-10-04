using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour {

	Image bar;

	void Start () {
		bar = GetComponent<Image> ();
	}

	public void Cooldown(float cooldown) {
		Vector3 scale = bar.transform.localScale;
		scale.x = 0;
		bar.transform.localScale = scale;
		StartCoroutine (CooldownCoroutine (cooldown));
	}

	IEnumerator CooldownCoroutine(float cooldown) {
		float index = 0;
		while (index < cooldown) {
			Vector3 scale = bar.transform.localScale;
			scale.x = index / cooldown;
			bar.transform.localScale = scale;
			index += Time.deltaTime;
			yield return null;
		}
	}
}
