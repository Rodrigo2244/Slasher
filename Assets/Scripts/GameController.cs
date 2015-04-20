using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public bool isPaused;
	public bool isLoaded = false;
	public bool changedAudio = false;

	public GameObject numDisplay;

	public bool[] hasWon;
	public bool[] hasDied;
	
	public AudioSource gameMusic;

	public AudioSource violin;
	public AudioClip altSound;

	public AudioSource[] screams;

	void Start(){
		if(GameObject.Find("Player Num Text") != null){
			numDisplay = GameObject.Find("Player Num Text");
		}

		Screen.showCursor = false;
	}

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

		if((hasWon[0] == true || hasDied[0] == true) && (hasWon[1] == true || hasDied[1] == true) && (hasWon[2] == true || hasDied[2] == true) && (hasWon[3] == true || hasDied[3] == true)){
			if(!isLoaded){
				Application.LoadLevel("Main Menu");
				isLoaded = true;
				changedAudio = false;
			}
		}

		if(numDisplay != null){
			if(numPlayers == 1){
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victim";
			}else{
				numDisplay.GetComponent<Text>().text = numPlayers.ToString()+" Victims";
			}
		}

		if(Input.GetButtonDown("Pause") && Application.loadedLevel != 1){
			Pause();
		}

		if(Application.loadedLevel > 4 && numPlayers == 1 && GameObject.Find("Slasher")!=null && !changedAudio){
			GameObject.Find("AudioListener").GetComponent<AudioListener>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<AudioListener>().enabled = true;
			GameObject.Find("Slasher").transform.GetChild(0).gameObject.GetComponent<AudioSource>().clip = altSound;
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
		hasWon[playerNumber] = true;
	}

	public void HasDied(int playerNumber){
		violin.Play ();
		screams[Random.Range (0, screams.Length)].Play();
		hasDied[playerNumber] = true;
	}
}
