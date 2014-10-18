using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public float sfxVol;
	public float musicVol;
	public bool isPaused;

	public bool[] hasWon;
	public bool[] hasDied;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update(){
		hasWon = new bool[numPlayers];
		hasDied = new bool[numPlayers];
		for(int i = 0; i < numPlayers; i++){
			if(hasWon[i] == true || hasDied[i] == true){
				if(i == numPlayers - 1)
					print ("YAY");
					Application.LoadLevel("Scoreboard");
			}
			else
				break;
		}
	}
}
