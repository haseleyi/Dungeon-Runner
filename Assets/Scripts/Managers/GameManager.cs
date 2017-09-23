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

	public AudioSource uiSound, startSound;
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
		AudioSource[] sounds = GetComponents<AudioSource> ();
		uiSound = sounds [0];
		startSound = sounds [1];
	}

	public void Pause() {
		uiSound.Play ();
		Time.timeScale = 0;
		gameState = GameState.Paused;
	}

	public void Unpause() {
		uiSound.Play ();
		Time.timeScale = 1;
		gameState = GameState.Running;
	}

	public void Quit() {
		uiSound.Play ();
		Application.Quit ();	
	}

	public void LoadScene(string scene) {
		uiSound.Play ();
		SceneManager.LoadScene (scene);
	}
}
