using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int numPlayers;
	public float sfxVol;
	public float musicVol;
	public bool isPaused;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
}
