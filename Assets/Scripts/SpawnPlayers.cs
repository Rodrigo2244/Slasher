using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayers : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
		int playerNum = 4;
		var respawns = new List<GameObject>();

		foreach (GameObject respawn in GameObject.FindGameObjectsWithTag ("Respawn")) {
			respawns.Add(respawn);
		}

		for (var i = 0; i < playerNum; i++) {
			var index = Random.Range (0, respawns.Count - 1);
			Instantiate(Player, respawns[index].transform.position, respawns[index].transform.rotation );
			Debug.Log (respawns[index].name);
			respawns.RemoveAt(index);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
