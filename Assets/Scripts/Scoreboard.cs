using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	public GameObject gameController;
	public bool[] hasDied;
	public bool[] hasWon;
	public int numPlayers;
	Rect buttonRect = new Rect(Screen.width / 2 - 8, (2 * Screen.height / 3) - 30 ,150,60);

	// Use this for initialization
	void Start () {
		numPlayers = gameController.GetComponent<GameController>().numPlayers;
		hasWon = gameController.GetComponent<GameController>().hasWon;
		hasDied = gameController.GetComponent<GameController>().hasDied;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		for(int i = 0; i < numPlayers; i++){
			if(hasWon[i] == true)
				GUI.Label(new Rect(Screen.width/2, Screen.height/2-i*2, 100, 100), "Player " +(i+1)+"has survived.");
			if(hasDied[i] == true)
				GUI.Label(new Rect(Screen.width/2, Screen.height/2-i*2, 100, 100), "Player " +(i+1)+"has survived.");
		}
		if(GUI.Button(buttonRect,"Return to Menu")){
			Application.LoadLevel("Menus");
		}
	}
}
