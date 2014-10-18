using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int numPlayers;

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}
}
