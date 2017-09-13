using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

	public float firstSpawn;
	public float spawnEvery;
	public float chanceOfEnemy;

	public GameObject gruntPrefab;
	public GameObject archerPrefab;
	public GameObject tankPrefab;
	public GameObject suicidePrefab;

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
//			if (random.NextDouble () < chanceOfEnemy) {
//				SpawnRandomPrefab (gruntPrefab, archerPrefab);
//			} else {
//				SpawnRandomPrefab (firePrefab, trapPrefab);
//			}
			SpawnPrefab (gruntPrefab);
		}
	}
}
