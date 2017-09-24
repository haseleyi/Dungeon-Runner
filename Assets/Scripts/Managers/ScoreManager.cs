using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text coinsText, totalScore;
	public static ScoreManager instance;
	public int coinValue;
	public int upgradePrice;
	public int coins;
	int score;

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
		score += numCoins * coinValue;
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

	public void ScoreEnemy(int enemyValue) {
		score += enemyValue;
	}
}
