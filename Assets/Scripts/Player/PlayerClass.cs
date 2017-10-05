using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {

	public float cooldown = 1;
	public virtual string title {get; protected set;}

	protected bool canAbility;
	public bool upgraded;
	public bool isInvulnerable = false;

	public virtual void Ability () {
	}

	protected IEnumerator CooldownCoroutine () {
		HudManager.instance.cooldownBarFront.GetComponent<CooldownBar>().Cooldown(cooldown);
		yield return new WaitForSeconds (cooldown);
		canAbility = true;
	}
}
