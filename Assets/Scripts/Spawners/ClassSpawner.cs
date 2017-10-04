using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSpawner : Spawner {

	public float firstSpawn;
	public float spawnEvery;

	public GameObject warriorPrefab;
	public GameObject magePrefab;
	public GameObject rangerPrefab;
	public GameObject thiefPrefab;

	void Start() {
		StartCoroutine (SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		SpawnRandomPrefab(warriorPrefab, magePrefab, rangerPrefab, thiefPrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			SpawnRandomPrefab(warriorPrefab, magePrefab, rangerPrefab, thiefPrefab);
		}
	}
}
