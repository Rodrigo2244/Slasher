using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayers : MonoBehaviour {
	public GameObject Player;
	public int playerNum;
	public GameObject controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("Game Controller");
		playerNum = controller.GetComponent <GameController>().playerNum;
		var respawns = new List<GameObject>();

		foreach (GameObject respawn in GameObject.FindGameObjectsWithTag ("Respawn")) {
			respawns.Add(respawn);
		}

		for (var i = 0; i < playerNum; i++) {
			Player.GetComponent <MouseLook>().PlayerId = i;
			Player.GetComponent <FPSInputController>().PlayerId = i;
			Player.GetComponentInChildren <MouseLook>().PlayerId = i;

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
