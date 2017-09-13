using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	public GUIText coinsText;
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
		coinsText.text = "Coins: " + coins;
	}
}
