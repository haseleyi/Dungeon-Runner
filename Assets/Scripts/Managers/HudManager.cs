using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	public Text coinsText, scoreText, scoreIncrementText, storeAlertText;
	public Image cooldownBarBack, cooldownBarFront;
	public static HudManager instance;

	void Awake () {
		instance = this;
	}
}
