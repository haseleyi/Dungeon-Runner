using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text coinsText;
	private int coins;

	// Use this for initialization
	void Start () {
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
