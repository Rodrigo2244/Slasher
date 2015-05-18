using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public bool isPaused;
	public bool changedAudio = false;

	public GameObject numDisplay;

	public playerID.finishState[] endStates;
	
	public AudioSource gameMusic;

	public AudioSource violin;

	void Start(){
		if(GameObject.Find("Player Num Text") != null){
			numDisplay = GameObject.Find("Player Num Text");
		}

		Screen.showCursor = false;
	}

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	void OnLevelWasLoad(int level){

	}

	public IEnumerator SpawnSlasher(GameObject Slasher){
		yield return new WaitForSeconds(10);
		Slasher.SetActive(true);
	}

	void Update(){

		for(int i = 0;i < endStates.Length;i++){
			if(endStates[i] == playerID.finishState.neither){
				continue;
			}
			Application.LoadLevel("Main Menu");
			Destroy(gameObject);
		}

		if(numDisplay != null){
			if(numPlayers == 1){
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victim";
			}else{
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victims";
			}
		}

		if(Input.GetButtonDown("Pause") && Application.loadedLevel != 1){
			//Pause();
		}

		if(Application.loadedLevel > 4 && numPlayers == 1 && GameObject.Find("Slasher")!=null && !changedAudio){
			GameObject.Find("AudioListener").GetComponent<AudioListener>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<AudioListener>().enabled = true;
			changedAudio = true;
			GameObject.Find("Slasher").transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
		}
	}

	public void Pause(){
		if(isPaused){
			transform.GetChild(0).gameObject.SetActive(false);
			isPaused = false;
			Time.timeScale = 1;
		}else{
			transform.GetChild(0).gameObject.SetActive(true);
			isPaused = true;
			Time.timeScale = 0;
		}
	}
	
	public void Quit(){
		Time.timeScale = 1;
		Application.LoadLevel(1);
		Destroy(this.gameObject);
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
		endStates[playerNumber] = playerID.finishState.win;
	}

	public void HasDied(int playerNumber){
		violin.Play();
		endStates[playerNumber] = playerID.finishState.lose;
	}
}
