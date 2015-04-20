 using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public bool isBegin;
	public GameObject story;

	public GameObject gameController;

	public int numPlayers;

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.Return) && isBegin){
			Application.LoadLevel("LoadingScreen");
		}*/
	}

	IEnumerator Begin(){
		story.SetActive(true);
		isBegin = true;
		GameObject.Find("GUI").SetActive(false);
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
