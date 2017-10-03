using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int coinValue;
	public int upgradePrice;
	public int coins;
	public int coinsCollected;
	public int gruntsDefeated;
	public int archersDefeated;
	public int tanksDefeated;
	public int score;

	void Start () {
		instance = this;
//		coins = 0;
		coinsCollected = 0;
		gruntsDefeated = 0;
		archersDefeated = 0;
		tanksDefeated = 0;
		score = 0;
		StartCoroutine (SurvivalCoroutine ());
		HudManager.instance.coinsText.text = coins.ToString ();
	}

	void Update() {
		HudManager.instance.scoreText.text = "Score: " + score.ToString ();
		HudManager.instance.coinsText.text = coins.ToString();
		if (coins >= 10) {
			HudManager.instance.storeAlertText.gameObject.SetActive (true);
		} else {
			HudManager.instance.storeAlertText.gameObject.SetActive (false);
		}
	}

	public void AddCoins (int numCoins) {
		coins += numCoins;
		coinsCollected += numCoins;
		IncrementScore(numCoins * coinValue);
	}

	public void AddChest() {
		StartCoroutine (AddChestCoroutine ());
	}

	IEnumerator AddChestCoroutine() {
		ScoreManager.instance.coinsCollected += 3 * PlayerController.instance.coinMultiplier;
		ScoreManager.instance.IncrementScore (300);
		ScoreManager.instance.coins += PlayerController.instance.coinMultiplier;
		yield return new WaitForSeconds (.15f);
		ScoreManager.instance.coins += PlayerController.instance.coinMultiplier;
		yield return new WaitForSeconds (.15f);
		ScoreManager.instance.coins += PlayerController.instance.coinMultiplier;
	}

	IEnumerator SurvivalCoroutine() {
		while (true) {
			yield return new WaitForSeconds (.1f);
			score++;
		}
	}

	public bool PurchaseSuccess() {
		if (coins >= upgradePrice) {
			coins -= upgradePrice;
			HudManager.instance.coinsText.text = coins.ToString();
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
		HudManager.instance.scoreIncrementText.text = "+ " + value.ToString ();
		yield return new WaitForSeconds (2);
		HudManager.instance.scoreIncrementText.text = "";
	}
}
