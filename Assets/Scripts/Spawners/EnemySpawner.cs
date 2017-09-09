using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

	public int firstSpawn;
	public int spawnEvery;
	public float chanceOfEnemy;

	public GameObject GruntPrefab;
	public GameObject ArcherPrefab;
	public GameObject TankPrefab;
	public GameObject SuicidePrefab;

	public GameObject FirePrefab;
	public GameObject TrapPrefab;

	void Start () {
		StartCoroutine(SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		if (random.NextDouble() < .5) {
			SpawnPrefab(FirePrefab);
		} else {
			SpawnPrefab(TrapPrefab);
		}
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			if (random.NextDouble () < chanceOfEnemy) {
				SpawnRandomPrefab (GruntPrefab, ArcherPrefab);
			}
			else {
				SpawnRandomPrefab (FirePrefab, TrapPrefab);
			}
		}
	}
}
