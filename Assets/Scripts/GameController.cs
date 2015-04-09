using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public bool isPaused;
	public bool isLoaded = false;

	public GameObject numDisplay;

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
		}
		if(numDisplay != null){
			if(numPlayers == 1){
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victim";
			}else{
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victims";
			}
		}	
	}

	public void More(){
		if(numPlayers != 4){
			numPlayers++;
		}
	}

	public void Less(){
		if(numPlayers != 1){
			numPlayers--;
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
