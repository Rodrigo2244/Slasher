using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	public GameObject gameController;
	public bool[] hasDied;
	public bool[] hasWon;
	public int numPlayers;
	Rect buttonRect;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("Game Controller");
		numPlayers = gameController.GetComponent<GameController>().numPlayers;
		hasWon = gameController.GetComponent<GameController>().hasWon;
		hasDied = gameController.GetComponent<GameController>().hasDied;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		buttonRect= new Rect(Screen.width / 2-75, (2 * Screen.height / 3) ,150,60);
		for(int i = 0; i < numPlayers; i++){
			if(hasWon[i] == true)
				GUI.Label(new Rect(Screen.width/2-60, Screen.height/2+i*20-100, 250, 200), "Player " +(i+1)+" has survived.");
			if(hasDied[i] == true)
				GUI.Label(new Rect(Screen.width/2-60, Screen.height/2+i*20-100, 250, 200), "Player " +(i+1)+" has died.");
		}
		if(GUI.Button(buttonRect,"Return to Menu")){
			Application.LoadLevel("Menus");
		}
	}
}
