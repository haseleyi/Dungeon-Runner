using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSpawner : Spawner {

	public int firstSpawn;
	public int spawnEvery;

	public GameObject WarriorPrefab;
	public GameObject MagePrefab;
	public GameObject RangerPrefab;
	public GameObject ThiefPrefab;
	public GameObject ClericPrefab;

	void Start() {
		StartCoroutine (SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		SpawnRandomPrefab(WarriorPrefab, MagePrefab, RangerPrefab, ThiefPrefab, ClericPrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			SpawnRandomPrefab(WarriorPrefab, MagePrefab, RangerPrefab, ThiefPrefab, ClericPrefab);
		}
	}
}
