using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

	public float firstSpawn;
	public float spawnEvery;
	public float chanceOfTank;
	public float chanceOfArcher;

	public GameObject gruntPrefab;
	public GameObject archerPrefab;
	public GameObject tankPrefab;

	public GameObject firePrefab;
	public GameObject trapPrefab;

	void Start () {
		StartCoroutine(SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
//		if (random.NextDouble() < .5) {
//			SpawnPrefab(firePrefab);
//		} else {
//			SpawnPrefab(trapPrefab);
//		}
		SpawnPrefab (gruntPrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			double rand = random.NextDouble ();
			if (rand < chanceOfTank) {
				SpawnTank (tankPrefab);
			} else if (rand < chanceOfArcher) {
				SpawnPrefab (archerPrefab);
			} else {
				SpawnPrefab (gruntPrefab);
			}
		}
	}
}
