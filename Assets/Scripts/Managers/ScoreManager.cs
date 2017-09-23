using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text coinsText, totalScore;
	public static ScoreManager instance;
	public int coinScore;
	public int upgradePrice;
	int coins;
	int score;

	// Use this for initialization
	void Start () {
		instance = this;
		coins = 0;
		score = 0;
		StartCoroutine (DistanceScoreCoroutine ());
		UpdateCoins ();
	}

	void Update() {
		totalScore.text = "Score: " + score.ToString ();
	}

	public void AddCoins (int numCoins) {
		coins += numCoins;
		score += numCoins * coinScore;
		UpdateCoins ();
	}

	void UpdateCoins () {
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
			UpdateCoins ();
			return true;
		}
		return false;
	}
}
