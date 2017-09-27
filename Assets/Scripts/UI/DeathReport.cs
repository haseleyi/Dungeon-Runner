using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathReport : MonoBehaviour {

	public GameObject deathReportCanvas;
	public static DeathReport instance;
	public Text totalScore, timeSurvived, coinsCollected, gruntsDefeated, archersDefeated, tanksDefeated;
	public bool displayed;

	void Start () {
		deathReportCanvas.SetActive (false);
		displayed = false;
		instance = this;
	}
	
	public void LoadDeathReport() {
		deathReportCanvas.SetActive (true);
		GameManager.instance.EndRun ();
		totalScore.text = "Total Score: " + ScoreManager.instance.score.ToString();
		gruntsDefeated.text = "Grunts defeated: " + ScoreManager.instance.gruntsDefeated.ToString();
		archersDefeated.text = "Archers defeated: " + ScoreManager.instance.archersDefeated.ToString ();
		tanksDefeated.text = "Tanks defeated: " + ScoreManager.instance.tanksDefeated.ToString ();
		coinsCollected.text = "Coins collected: " + ScoreManager.instance.coinsCollected.ToString ();
		timeSurvived.text = "Time survived: " + System.Math.Round(Time.timeSinceLevelLoad, 2).ToString();
		displayed = true;
	}
}
