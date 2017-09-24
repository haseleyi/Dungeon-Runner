using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public GameObject deathReportCanvas;
	public Text coinsText, totalScore, scoreIncrement;
	public static ScoreManager instance;
	public int coinValue;
	public int upgradePrice;
	public int coins;
	public int coinsCollected;
	public int gruntsDefeated;
	public int archersDefeated;
	public int tanksDefeated;
	public float timeSurvived;
	public int score;

	void Start () {
		deathReportCanvas.SetActive (false);
		instance = this;
		coins = 0;
		coinsCollected = 0;
		gruntsDefeated = 0;
		archersDefeated = 0;
		tanksDefeated = 0;
		score = 0;
		StartCoroutine (SurvivalCoroutine ());
		coinsText.text = coins.ToString ();
	}

	void Update() {
		totalScore.text = "Score: " + score.ToString ();
	}

	public void AddCoins (int numCoins) {
		coins += numCoins;
		coinsCollected += numCoins;
		IncrementScore(numCoins * coinValue);
		coinsText.text = coins.ToString();
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

	public void LoadDeathReport() {
		timeSurvived = Time.timeSinceLevelLoad;
		deathReportCanvas.SetActive (true);
		GameManager.instance.EndRun ();
		print ("Coins collected: " + coinsCollected);
		print ("Grunts defeated: " + gruntsDefeated);
		print ("Archers defeated: " + archersDefeated);
		print ("Tanks defeated: " + tanksDefeated);
		print ("Time survived: " + timeSurvived);
		print ("Total score: " + score);
	}
}
