using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	protected System.Random random = new System.Random();
		
	protected void SpawnRandomPrefab(params GameObject[] prefabs) {
		if (LaneManager.instance.IsFreeLane()) {
			GameObject prefab = prefabs [random.Next (prefabs.Length)];
			float location = LaneManager.instance.GetFreeLane (false);
			Instantiate (prefab, new Vector2 (17, location), Quaternion.identity);
			StartCoroutine (LaneManager.instance.DisableSpawningCoroutine(location, false));
		}
	}

	protected void SpawnPrefab(GameObject prefab) {
		if (LaneManager.instance.IsFreeLane()) {
			float location = LaneManager.instance.GetFreeLane(false);
			Instantiate (prefab, new Vector2 (17, location), Quaternion.identity);
			StartCoroutine (LaneManager.instance.DisableSpawningCoroutine(location, false));
		}
	}
}