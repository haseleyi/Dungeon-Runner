using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public float cooldown1 = 1;
	public virtual string title {get; protected set;}

	protected bool canAbility1;
	public bool upgraded;
	public bool isInvulnerable = false;

	public virtual void Ability1 () {
	}

	protected IEnumerator Cooldown1Coroutine () {
		HudManager.instance.cooldownBarFront.GetComponent<CooldownBar>().Cooldown(cooldown1);
		yield return new WaitForSeconds (cooldown1);
		canAbility1 = true;
	}
}
