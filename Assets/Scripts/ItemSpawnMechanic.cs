using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnMechanic : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] itemList;

	// Use this for initialization
	void Start () {

		spawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawn");
		if (itemList.Length != 0) {
			if (spawnPoints.Length != 0) {
				foreach (GameObject point in spawnPoints) {
					GameObject item = itemList [Random.Range (0, itemList.Length)];
					Instantiate (item, point.transform.position, point.transform.rotation);
				}
			}
		}
	}
}
