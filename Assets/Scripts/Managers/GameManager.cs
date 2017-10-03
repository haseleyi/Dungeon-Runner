// <copyright file="GameManager.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>14/08/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// In control of the game flow. Uses static fields to store information and static functions for outside communication.
/// Use this to transition between levels, request the current game state and pause/unpause the game.
/// </summary>
public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public enum GameState
	{
		MainMenu,
		Running,
		Paused
	}

	public static GameState gameState;

	void Awake() {
		instance = this;
	}

	public void PlayUISound() {
		SoundManager.instance.uiInteraction.Play ();
	}

	public void Pause() {
		PlayUISound ();
		Time.timeScale = 0;
		gameState = GameState.Paused;
	}

	public void Unpause() {
		PlayUISound ();
		Time.timeScale = 1;
		gameState = GameState.Running;
	}

	public IEnumerator MainMenuCoroutine() {
		PlayUISound ();
		Time.timeScale = .01f;
		yield return new WaitForSeconds (.001f);
		Time.timeScale = 1;
		gameState = GameState.Running;
		gameState = GameState.MainMenu;
		SceneManager.LoadScene ("MainMenu");
	}

	public void EndRun() {
		Time.timeScale = 0;
		gameState = GameState.Paused;
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene (scene);
		Time.timeScale = 1;
		gameState = GameState.Running;
	}

	public void MainMenu() {
		StartCoroutine (MainMenuCoroutine());
	}
}
