﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text coinsText, totalScore, scoreIncrement;
	public static ScoreManager instance;
	public int coinValue;
	public int upgradePrice;
	public int coins;
	public int gruntsDefeated;
	public int archersDefeated;
	public int tanksDefeated;
	int score;

	void Start () {
		instance = this;
		coins = 0;
		score = 0;
		gruntsDefeated = 0;
		archersDefeated = 0;
		tanksDefeated = 0;
		StartCoroutine (DistanceScoreCoroutine ());
		coinsText.text = coins.ToString ();
	}

	void Update() {
		totalScore.text = "Score: " + score.ToString ();
	}

	public void AddCoins (int numCoins) {
		coins += numCoins;
		IncrementScore(numCoins * coinValue);
		coinsText.text = coins.ToString();
	}

	IEnumerator DistanceScoreCoroutine() {
		while (true) {
			yield return new WaitForSeconds (.1f);
			score++;
		}
	}

	public bool PurchaseSuccess() {
		if (coins >= upgradePrice) {
			coins -= upgradePrice;
			coinsText.text = coins.ToString();
			return true;
		}
		return false;
	}

	public void IncrementScore(int value) {
		StopCoroutine("ScoreIncrementCoroutine");
		StartCoroutine ("ScoreIncrementCoroutine", value);
	}

	public IEnumerator ScoreIncrementCoroutine(int value) {
		score += value;
		scoreIncrement.text = "+ " + value.ToString ();
		yield return new WaitForSeconds (2);
		scoreIncrement.text = "";
	}
}
