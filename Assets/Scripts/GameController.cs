using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public float sfxVol;
	public float musicVol;
	public bool isPaused;
	public bool isLoaded = false;

	public bool[] hasWon;
	public bool[] hasDied;
	
	public AudioSource gameMusic;

	public AudioSource violin;

	public AudioSource[] screams;

	void Awake(){
		hasWon = new bool[4];
		hasDied = new bool[4];

		DontDestroyOnLoad(transform.gameObject);
	}

	void Update(){
		for(int i = 0; i < numPlayers; i++){
			if(hasWon[i] == true || hasDied[i] == true){
				if(i == numPlayers - 1 && !isLoaded){
					Application.LoadLevel("Scoreboard");
					isLoaded = true;
				}
			}
			else
				break;
		}
	}

	public void HasWon(int playerNumber){
		hasWon[playerNumber] = true;
	}

	public void HasDied(int playerNumber){
		violin.Play ();
		screams[Random.Range (0, screams.Length)].Play();
		hasDied[playerNumber] = true;
	}
}
