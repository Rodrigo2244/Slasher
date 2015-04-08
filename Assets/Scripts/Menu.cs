using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public bool isBegin;
	public GUIText story;

	public GameObject gameController;

	public int numPlayers;
	public static int minPlayers = 1;
	public static int maxPlayers = 4;

	// Use this for initialization
	void Start () {
		numPlayers = minPlayers;
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) && isBegin){
			Application.LoadLevel("LoadingScreen");
		}
	}

	void Awake(){
		numPlayers = minPlayers;
	}

	IEnumerator Begin(){
		story.gameObject.SetActive(true);
		GameObject.Find("GUI").SetActive(false);
		isBegin = true;
		GameObject.Find("Main Camera").animation.Play("gameStart");
		GameObject.Find("Game Controller").GetComponent<GameController>().numDisplay = null;
		yield return new WaitForSeconds(10f);
		Application.LoadLevel("LoadingScreen");
		gameController.GetComponent<GameController>().gameMusic.Play ();
	}

	void Quit(){
		Application.Quit();
	}
}
