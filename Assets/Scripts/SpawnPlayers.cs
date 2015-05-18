using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPlayers : MonoBehaviour {
	public GameObject Player;
	public int playerNum;
	public GameObject controller;
	public Material player1Texture;
	public Material player2Texture;
	public Material player3Texture;
	public Material player4Texture;

	// Use this for initialization
	void Start () {
		if(GameObject.Find("Game Controller") != null){
			controller = GameObject.Find("Game Controller");
			playerNum = controller.GetComponent<GameController>().numPlayers;
		}

		List<GameObject> respawns = new List<GameObject>();

		foreach (GameObject respawn in GameObject.FindGameObjectsWithTag("Respawn")){
			respawns.Add(respawn);
		}

		for (int i = 0; i < playerNum; i++) {
			int index = Random.Range (0, respawns.Count);
			GameObject spawnedPlayer = (GameObject)Instantiate(Player, respawns[index].transform.position, respawns[index].transform.rotation );
			spawnedPlayer.GetComponent<flashlightMechanic>().PlayerId = i;
			spawnedPlayer.GetComponent<playerID>().ID = i;
			spawnedPlayer.GetComponent<FPSInputController>().PlayerId = i;
			spawnedPlayer.GetComponent<cameraControl>().PlayerId = i;
			spawnedPlayer.transform.GetChild(1).GetComponent<cameraControl>().PlayerId = i;
			switch(i){
				case 0: 
					spawnedPlayer.transform.GetChild(2).GetChild(3).GetComponent<SkinnedMeshRenderer>().material = player1Texture;
				break;
				case 1:
					spawnedPlayer.transform.GetChild(2).GetChild(3).GetComponent<SkinnedMeshRenderer>().material = player2Texture;
				break;
				case 2:
					spawnedPlayer.transform.GetChild(2).GetChild(3).GetComponent<SkinnedMeshRenderer>().material = player3Texture;
				break;
				case 3:
					spawnedPlayer.transform.GetChild(2).GetChild(3).GetComponent<SkinnedMeshRenderer>().material = player4Texture;
				break;
			}
			if(playerNum > 2){
				if(spawnedPlayer.GetComponent <playerID>().ID == 0){
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,.5f,.5f,.5f);
				}else if(spawnedPlayer.GetComponent <playerID>().ID == 1){
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(.5f,.5f,.5f,.5f);
				}else if(spawnedPlayer.GetComponent <playerID>().ID == 2){
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,.5f,.5f);
				}else if(spawnedPlayer.GetComponent <playerID>().ID == 3)	{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(.5f,0,.5f,.5f);
				}
			}
			else if(playerNum > 1){
				if(spawnedPlayer.GetComponent <playerID>().ID == 0){
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,.5f,1,.5f);
				}else{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,1,.5f);
				}
			}else{
				spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,1,1);
			}

			Screen.showCursor = false;

			respawns.RemoveAt(index);
		}
	}
}