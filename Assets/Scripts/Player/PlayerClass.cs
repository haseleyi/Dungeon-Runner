using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public float attackCooldown = 0.5f;
	public float abilityCooldown = 5;
	public float duration = 15;

	protected bool canAttack;
	protected bool canAbility;

	void Start () {
		canAttack = true;
		canAbility = true;
		Timer ();
	}

	protected IEnumerator Timer () {
		yield return new WaitForSeconds (duration);
		Destroy (gameObject);
	}

	protected IEnumerator WaitForAttack () {
		yield return new WaitForSeconds (attackCooldown);
		canAttack = true;
	}

	protected IEnumerator WaitForAbility () {
		yield return new WaitForSeconds (abilityCooldown);
		canAbility = true;
	}
}
