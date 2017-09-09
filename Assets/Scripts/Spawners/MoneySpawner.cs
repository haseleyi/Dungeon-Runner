using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : Spawner {

	public int firstSpawn;
	public int spawnEvery;
	public float chanceOfChest;

	public GameObject CoinPrefab;
	public GameObject ChestPrefab;

	void Start () {
		StartCoroutine(SpawnCoroutine());
	}
	
	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds (firstSpawn);
		SpawnPrefab(CoinPrefab);
		while (true) {
			yield return new WaitForSeconds (spawnEvery);
			if (random.NextDouble () < chanceOfChest) {
				SpawnPrefab (ChestPrefab);
			}
			else {
				SpawnPrefab (CoinPrefab);
			}
		}
	}
}
