using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource fireball, uiInteraction, swordClash, arrow, coin, swipe, drums,
		enemyDeath1, enemyDeath2, enemyDeath3, tankDeath, playerDeath, hit;

	public static SoundManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		AudioSource[] sounds = GetComponents<AudioSource> ();
		fireball = sounds [0];
		uiInteraction = sounds [1];
		swordClash = sounds [2];
		arrow = sounds [3];
		coin = sounds [4];
		swipe = sounds [5];
		drums = sounds [6];
		enemyDeath1 = sounds [7];
		enemyDeath2 = sounds [8];
		enemyDeath3 = sounds [9];
		tankDeath = sounds [10];
		playerDeath = sounds [11];
		hit = sounds [12];
	}
}
