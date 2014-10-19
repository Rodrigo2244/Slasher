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
		controller = GameObject.Find("Game Controller");
		playerNum = controller.GetComponent <GameController>().numPlayers;
		var respawns = new List<GameObject>();

		foreach (GameObject respawn in GameObject.FindGameObjectsWithTag ("Respawn")) {
			respawns.Add(respawn);
		}

		for (var i = 0; i < playerNum; i++) {


			var index = Random.Range (0, respawns.Count);
			GameObject spawnedPlayer = (GameObject)Instantiate(Player, respawns[index].transform.position, respawns[index].transform.rotation );
			MouseLook[] mouselooks = spawnedPlayer.GetComponentsInChildren <MouseLook>();
			foreach(MouseLook scripts in  mouselooks)
				scripts.PlayerId = i;
			spawnedPlayer.GetComponent<flashlightMechanic>().PlayerId = i;
			spawnedPlayer.GetComponent <FPSInputController>().PlayerId = i;
			if(i == 0)
				spawnedPlayer.GetComponentInChildren<SkinnedMeshRenderer>().materials[0] = player1Texture;
			if(i == 1)
				spawnedPlayer.GetComponentInChildren<SkinnedMeshRenderer>().materials[0] = player2Texture;
			if(i == 2)
				spawnedPlayer.GetComponentInChildren<SkinnedMeshRenderer>().materials[0] = player3Texture;
			if(i == 3)
				spawnedPlayer.GetComponentInChildren<SkinnedMeshRenderer>().materials[0] = player4Texture;
			if(playerNum > 2)
			{
				if(spawnedPlayer.GetComponent <FPSInputController>().PlayerId == 0)
				{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,.5f,.5f,.5f);
				}
				if(spawnedPlayer.GetComponent <FPSInputController>().PlayerId == 1)
				{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(.5f,.5f,.5f,.5f);
				}
				if(spawnedPlayer.GetComponent <FPSInputController>().PlayerId == 2)
				{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,.5f,.5f);
				}
				if(spawnedPlayer.GetComponent <FPSInputController>().PlayerId == 3)				//{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(.5f,0,.5f,.5f);
				//}

			}
			else if(playerNum > 1)
			{
				if(spawnedPlayer.GetComponent <FPSInputController>().PlayerId == 0)
				{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,.5f,1,.5f);
				}
				else
				{
					spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,1,.5f);
				}
			}
			else
			{
				spawnedPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0,1,1);
			}

		
			Debug.Log (respawns[index].name);
			respawns.RemoveAt(index);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
