using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnMechanic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var itemList = new List<GameObject>();

		foreach (GameObject item in GameObject.FindGameObjectsWithTag ("Item")) {
			itemList.Add(item);
		}

		foreach (GameObject ItemSpawn in GameObject.FindGameObjectsWithTag ("ItemSpawn")) {

			GameObject item = itemList[ Random.Range (0, itemList.Count)  ];

			GameObject newItem = Instantiate(item, ItemSpawn.transform.position, item.transform.rotation ) as GameObject;

			newItem.transform.parent = ItemSpawn.transform;

			newItem.transform.Rotate(newItem.transform.up * Random.Range(0, 361) );

		}
	}
}
