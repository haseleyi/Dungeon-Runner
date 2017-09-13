using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour {

	public List<float> laneLocations = new List<float> {-4, -2, 0, 2};
	public List<bool> laneIsOpen = new List<bool> {true, true, true, true};
	public float spawnDelay;
	public static LaneManager instance;
	
	void Start() {
		instance = this;
	}

	public IEnumerator DisableSpawningCoroutine(float location) {
		int laneIndex = laneLocations.IndexOf (location);
		laneIsOpen [laneIndex] = false;
		yield return new WaitForSeconds (spawnDelay);
		laneIsOpen [laneIndex] = true;
	}

	public bool IsFreeLane() {
		foreach (bool status in laneIsOpen) {
			if (status) {
				return true;
			}
		}
		return false;
	}

	public float GetFreeLane() {
		System.Random random = new System.Random ();
		int laneIndex;
		while (true) {
			laneIndex = random.Next (laneLocations.Count);
			if (laneIsOpen[laneIndex]) {
				return laneLocations[laneIndex];
			}
		}
	}
}
