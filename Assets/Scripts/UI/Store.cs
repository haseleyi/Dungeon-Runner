// <copyright file="PauseMenu.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>14/08/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Pause menu script. Provides functionality to Pause and Unpause the game and Go Back to the Main Menu. Controlled by buttons from the Unity UI.
/// Pressing ESC will also open and close the menu.
/// </summary>
public class Store : MonoBehaviour {

	public string mainMenuScene = "MainMenu";
	public GameObject pauseMenuCanvas;
	AudioSource upgradeSound;

	void Start() {
		GameManager.gameState = GameManager.GameState.Running;
		pauseMenuCanvas.SetActive (false);
		upgradeSound = GetComponent<AudioSource> ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			if (GameManager.gameState == GameManager.GameState.Running) {
				Pause ();
			}
			else if (GameManager.gameState == GameManager.GameState.Paused && !DeathReport.instance.displayed) {
				UnPause ();
			}
		}
	}

	public void UpgradeMage() {
		if (!PlayerController.instance.GetComponent<Mage> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Mage> ().upgraded = true;
			upgradeSound.Play ();
			Button[] buttons = GameObject.FindObjectsOfType<Button> ();
			foreach (Button button in buttons) {
				if (button.tag == "MageButton") {
					button.interactable = false;
					break;
				}
			}
		}
	}

	public void UpgradeRanger() {
		if (!PlayerController.instance.GetComponent<Ranger> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Ranger> ().upgraded = true;
			upgradeSound.Play ();
			Button[] buttons = GameObject.FindObjectsOfType<Button> ();
			foreach (Button button in buttons) {
				if (button.tag == "RangerButton") {
					button.interactable = false;
					break;
				}
			}
		}
	}

	public void UpgradeThief() {
		if (!PlayerController.instance.GetComponent<Thief> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Thief> ().upgraded = true;
			upgradeSound.Play ();
			Button[] buttons = GameObject.FindObjectsOfType<Button> ();
			foreach (Button button in buttons) {
				if (button.tag == "ThiefButton") {
					button.interactable = false;
					break;
				}
			}
		}
	}

	public void UpgradeWarrior() {
		if (!PlayerController.instance.GetComponent<Warrior> ().upgraded && ScoreManager.instance.PurchaseSuccess ()) {
			PlayerController.instance.GetComponent<Warrior> ().upgraded = true;
			upgradeSound.Play ();
			Button[] buttons = GameObject.FindObjectsOfType<Button> ();
			foreach (Button button in buttons) {
				if (button.tag == "WarriorButton") {
					button.interactable = false;
					break;
				}
			}
		}
	}

	public void Pause() {
		pauseMenuCanvas.SetActive (true);
		GameManager.instance.Pause ();
	}

	public void UnPause() {
		pauseMenuCanvas.SetActive (false);
		GameManager.instance.Unpause ();
	}
}
