using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public float cooldown1 = 1;
	public float cooldown2 = 2;
	public virtual string title {get; protected set;}

	protected bool canAbility1;
	protected bool canAbility2;
	public bool upgraded;
	public bool isInvulnerable = false;

	void Start () {
		title = "No class";
	}

	public virtual void Ability1 () {
	}

	public virtual void Ability2 () {
	}


	protected IEnumerator Cooldown1Coroutine () {
		yield return new WaitForSeconds (cooldown1);
		canAbility1 = true;
	}

	protected IEnumerator Cooldown2Coroutine () {
		yield return new WaitForSeconds (cooldown2);
		canAbility2 = true;
	}
}
