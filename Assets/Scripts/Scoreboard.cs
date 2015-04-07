using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	public GUIStyle gui;
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
		Screen.showCursor = true;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		buttonRect= new Rect(Screen.width / 2-75, (2 * Screen.height / 3) ,150,60);
		for(int i = 0; i < numPlayers; i++){
			if(hasWon[i] == true)
				GUI.Label(new Rect(Screen.width/2-100, Screen.height/2+i*60-250, 250, 200), "Player " +(i+1)+" has survived.",gui);
			if(hasDied[i] == true)
				GUI.Label(new Rect(Screen.width/2-100, Screen.height/2+i*60-250, 250, 200), "Player " +(i+1)+" has died.",gui);
		}
		if(GUI.Button(buttonRect,"Return to Menu",gui)){
			Destroy (gameController);
			Application.LoadLevel("Menus");
		}
	}

}
