using UnityEngine;
using System.Collections;

public class logoAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(startGame());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator startGame(){
		yield return new WaitForSeconds(7);
		Application.LoadLevel("Menus");
	}
}
