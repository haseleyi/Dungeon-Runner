using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text coinsText;
	private int coins;
	public static ScoreManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		coins = 0;
		UpdateCoins ();
	}

	public void AddCoins (int newCoinValue) {
		coins += newCoinValue;
		UpdateCoins ();
	}

	void UpdateCoins () {
		coinsText.text = "Coins: " + coins.ToString();
	}
}
