using UnityEngine;
using System.Collections;

public class logoAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(startGame());
		Rect logo = new Rect(Screen.width/2-guiTexture.pixelInset.width/2, Screen.height/2-guiTexture.pixelInset.height/2, guiTexture.pixelInset.width,guiTexture.pixelInset.height);
		guiTexture.pixelInset = logo;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator startGame(){
		yield return new WaitForSeconds(7);
		Application.LoadLevel("Main Menu");
	}
}
