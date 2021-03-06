﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUIStyle buttons;
	public GUIStyle normal;
	public bool isBegin;
	public GUIText story;

	const int menuButtonWidth = 300;
	const int buttonWidth = 84;
	const int buttonHeight = 60;

	public GameObject gameController;

	Rect buttonRect;
	Rect buttonRect2;
	Rect buttonRect3;
	Rect buttonRect4;

	enum Menus {Main, CharSelect, Settings};
	Menus currentMenu = Menus.Main;

	public int numPlayers;
	public static int minPlayers = 1;
	public static int maxPlayers = 4;

	public float masterVol = 0.5f;

	// Use this for initialization
	void Start () {
		numPlayers = minPlayers;
		gameController.GetComponent<GameController>().masterVol = masterVol;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && isBegin){
			Application.LoadLevel("LoadingScreen");
		}
	}

	void Awake(){
		numPlayers = minPlayers;
	}

	void OnGUI(){
		if(!isBegin){
			switch (currentMenu) {
			case Menus.Main:
				renderMain();
				break;
			case Menus.CharSelect:
				renderCharSelect();
				break;
			case Menus.Settings:
				renderSettings();
				break;
			}
		} else {
			
		}
	}

	void renderMain(){
		buttonRect = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)-140, menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)-70, menuButtonWidth, buttonHeight);
		buttonRect3 = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect4 = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)+70, menuButtonWidth, buttonHeight);
		
		if(GUI.Button(buttonRect,"Play",buttons)){
			currentMenu = Menus.CharSelect;
		}
		if(GUI.Button(buttonRect2,"Credits",buttons)){
			Application.LoadLevel("Credits");
		}
		if(GUI.Button(buttonRect3,"Settings",buttons)){
			currentMenu = Menus.Settings;
		}
		if(GUI.Button(buttonRect4,"Quit",buttons)){
			Application.Quit();
		}
	}

	void renderCharSelect(){
		buttonRect = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)+100, menuButtonWidth, buttonHeight);

		if (GUI.Button(new Rect(Screen.width /2 +200, Screen.height / 2, 300, 50), "More Victims",buttons)){
			if(numPlayers < maxPlayers)
				numPlayers++;
		}
		if (GUI.Button(new Rect(Screen.width / 2 -450, Screen.height / 2, 300, 50), "Less Victims",buttons)){
			if(numPlayers > minPlayers)
				numPlayers--;
		}

		GUI.Label(new Rect(Screen.width / 2-50, Screen.height /2-50,100,100), "Players Selected: "+numPlayers, normal);

		
		if(GUI.Button(buttonRect,"Play",buttons)){
			gameController.GetComponent<GameController>().numPlayers = numPlayers;
			Camera.main.animation.Play ("gameStart");
			StartCoroutine(Begin ());
		}
		if(GUI.Button(buttonRect2,"Back",buttons)){
			currentMenu = Menus.Main;
		}
	}

	void renderSettings(){
		buttonRect = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(Screen.width / 2 - (menuButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)+100, menuButtonWidth, buttonHeight);
		
		masterVol = GUI.HorizontalSlider(new Rect(Screen.width/2-50, Screen.height/2-30, 150, 25), masterVol, 0.0f, 1.0f);
		GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-75, 150,60), "Master Volume: " + (masterVol*100).ToString("f0"),normal);

		if(GUI.Button(buttonRect,"Apply",buttons)){
			gameController.GetComponent<GameController>().masterVol = masterVol;
		}
		if(GUI.Button(buttonRect2,"Back",buttons)){
			currentMenu = Menus.Main;
		}
	}

	IEnumerator Begin(){
		story.gameObject.SetActive(true);
		isBegin = true;
		yield return new WaitForSeconds(10f);
		Application.LoadLevel("LoadingScreen");
		gameController.GetComponent<GameController>().gameMusic.volume = masterVol;
		gameController.GetComponent<GameController>().gameMusic.Play ();
	}
}
