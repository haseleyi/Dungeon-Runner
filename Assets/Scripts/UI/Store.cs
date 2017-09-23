// <copyright file="PauseMenu.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>14/08/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Pause menu script. Provides functionality to Pause and Unpause the game and Go Back to the Main Menu. Controlled by buttons from the Unity UI.
/// Pressing ESC will also open and close the menu.
/// </summary>
public class Store : MonoBehaviour {

	public string mainMenuScene = "MainMenu";
	public GameObject pauseMenuCanvas;

	void Start() {
		GameManager.gameState = GameManager.GameState.Running;
		pauseMenuCanvas.SetActive (false);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			if (GameManager.gameState == GameManager.GameState.Running) {
				Pause ();
			}
			else if (GameManager.gameState == GameManager.GameState.Paused) {
				UnPause ();
			}
		}
	}

	public void UpgradeCleric() {
		if (!PlayerController.instance.GetComponent<Cleric> ().upgraded && ScoreManager.instance.PurchaseSuccess()) {
			PlayerController.instance.GetComponent<Cleric> ().upgraded = true;
		}
	}

	public void UpgradeMage() {
		if (!PlayerController.instance.GetComponent<Mage> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Mage> ().upgraded = true;
		}
	}

	public void UpgradeRanger() {
		if (!PlayerController.instance.GetComponent<Ranger> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Ranger> ().upgraded = true;
		}
	}

	public void UpgradeThief() {
		if (!PlayerController.instance.GetComponent<Thief> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Thief> ().upgraded = true;
		}
	}

	public void UpgradeWarrior() {
		if (!PlayerController.instance.GetComponent<Warrior> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Warrior> ().upgraded = true;
		}
	}

	public void Pause() {
		pauseMenuCanvas.SetActive (true);
		GameManager.Pause ();
	}

	public void UnPause() {
		pauseMenuCanvas.SetActive (false);
		GameManager.Unpause ();
	}

	public void GoToMainMenu() {
		GameManager.Unpause ();
		GameManager.gameState = GameManager.GameState.MainMenu;
		GameManager.LoadScene (mainMenuScene);
	}
}
