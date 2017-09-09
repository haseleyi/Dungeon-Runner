using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassUpgradeSpawner : Spawner {

	public int firstSpawn;
	public int spawnEvery;

	public GameObject WarriorUpgradePrefab;
	public GameObject MageUpgradePrefab;
	public GameObject RangerUpgradePrefab;
	public GameObject ThiefUpgradePrefab;
	public GameObject ClericUpgradePrefab;
	
	void Start () {
		StartCoroutine (SpawnCoroutine ());
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		SpawnRandomPrefab(WarriorUpgradePrefab, MageUpgradePrefab, RangerUpgradePrefab, ThiefUpgradePrefab, ClericUpgradePrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			SpawnRandomPrefab(WarriorUpgradePrefab, MageUpgradePrefab, RangerUpgradePrefab, ThiefUpgradePrefab, ClericUpgradePrefab);
		}
	}
}
