﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public float attackCooldown = 1;
	public float abilityCooldown = 2;
	public float duration = 3;
	public virtual string title {get; protected set;}

	protected bool canAttack;
	protected bool canAbility;

	void Start () {
		canAttack = true;
		canAbility = true;
		title = "No class";
	}

	public virtual void Attack () {
		// To be overridden in subclasses
	}

	public virtual void Ability () {
		// To be overridden in subclasses
	}


	protected IEnumerator WaitForAttackCoroutine () {
		yield return new WaitForSeconds (attackCooldown);
		canAttack = true;
	}

	protected IEnumerator WaitForAbilityCoroutine () {
		yield return new WaitForSeconds (abilityCooldown);
		canAbility = true;
	}
}
