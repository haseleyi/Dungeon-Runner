using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour {

	public List<float> laneLocations = new List<float> {-4, -2, 0, 2};
	public List<bool> laneIsOpen = new List<bool> {true, true, true, true};
	public float spawnDelay;
	public float xThreshold = -17;
	public static LaneManager instance;
	
	void Awake() {
		instance = this;
	}

	public IEnumerator DisableSpawningCoroutine(float location, bool tank) {
		int laneIndex = laneLocations.IndexOf (location);
		laneIsOpen [laneIndex] = false;
		if (tank) {
			laneIsOpen [laneIndex + 1] = false;
		}
		yield return new WaitForSeconds (spawnDelay);
		laneIsOpen [laneIndex] = true;
		if (tank) {
			laneIsOpen [laneIndex + 1] = true;
		}
	}

	public bool IsFreeLane() {
		return laneIsOpen.Contains (true) ? true : false;
	}

	public bool TwoAdjacentLanesFree() {
		for (int i = 0; i <= laneIsOpen.Count - 2; i++) {
			if (laneIsOpen[i] && laneIsOpen[i + 1]) {
				return true;
			}
		}
		return false;
	}

	public float GetFreeLane(bool tank) {
		System.Random random = new System.Random ();
		int laneIndex;
		while (true) {
			if (tank) {
				laneIndex = random.Next (laneLocations.Count - 1);
			} else {
				laneIndex = random.Next (laneLocations.Count);
			}
			if (laneIsOpen[laneIndex]) {
				return laneLocations[laneIndex];
			}
		}
	}
}
