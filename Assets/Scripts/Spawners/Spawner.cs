using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	protected System.Random random = new System.Random();
		
	protected void SpawnRandomPrefab(params GameObject[] prefabs) {
		GameObject prefab = prefabs [random.Next (prefabs.Length)];
		float location = GameManager.laneLocations [random.Next (GameManager.laneLocations.Count)];
		Instantiate (prefab, new Vector3 (17, location, 0), Quaternion.identity);
	}

	protected void SpawnPrefab(GameObject prefab) {
		float location = GameManager.laneLocations [random.Next (GameManager.laneLocations.Count)];
		Instantiate (prefab, new Vector3 (17, location, 0), Quaternion.identity);
	}
}