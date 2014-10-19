using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnMechanic : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject[] itemList;

	// Use this for initialization
	void Start () {

		spawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawn");

		foreach(GameObject point in spawnPoints){
			Instantiate(itemList[Random.Range(0,itemList.Length)],point.transform.position,point.transform.rotation);
		}
	}
}
