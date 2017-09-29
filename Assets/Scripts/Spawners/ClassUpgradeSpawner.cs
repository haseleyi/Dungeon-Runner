using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUpgradeSpawner : Spawner {

	public float firstSpawn;
	public float spawnEvery;

	public GameObject warriorUpgradePrefab;
	public GameObject mageUpgradePrefab;
	public GameObject rangerUpgradePrefab;
	public GameObject thiefUpgradePrefab;
	public GameObject clericUpgradePrefab;
	
	void Start () {
		StartCoroutine (SpawnCoroutine ());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		SpawnRandomPrefab(warriorUpgradePrefab, mageUpgradePrefab, rangerUpgradePrefab, thiefUpgradePrefab, clericUpgradePrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			SpawnRandomPrefab(warriorUpgradePrefab, mageUpgradePrefab, rangerUpgradePrefab, thiefUpgradePrefab, clericUpgradePrefab);
		}
	}
}
