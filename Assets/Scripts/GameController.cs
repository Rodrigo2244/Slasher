using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public float masterVol;
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

	public IEnumerator SpawnSlasher(GameObject Slasher){
		yield return new WaitForSeconds(10);
		Slasher.SetActive(true);
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

		AudioListener.volume = masterVol;

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
