using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	const int buttonWidth = 84;
	const int buttonHeight = 60;

	public GameObject gameController;

	Rect buttonRect;
	Rect buttonRect2;
	Rect buttonRect3;
	
	enum Menus {Main, CharSelect, Settings};
	Menus currentMenu = Menus.Main;

	public static int numPlayers;
	public static int minPlayers = 1;
	public static int maxPlayers = 4;

	// Use this for initialization
	void Start () {
		numPlayers = minPlayers;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
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
	}

	void renderMain(){
		buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)-140, buttonWidth, buttonHeight);
		buttonRect2 = new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)-70, buttonWidth, buttonHeight);
		buttonRect3 = new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
		
		if(GUI.Button(buttonRect,"Play")){
			currentMenu = Menus.CharSelect;
		}
		if(GUI.Button(buttonRect2,"Credits")){
			//Application.LoadLevel("Credits");
		}
		if(GUI.Button(buttonRect3,"Exit")){
			Application.Quit();
		}
	}

	void renderCharSelect(){
		buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2)-50, (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
		buttonRect2 = new Rect(Screen.width / 2 - (buttonWidth / 2)+50, (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);

		if (GUI.Button(new Rect(Screen.width / 2 +40, (2 * Screen.height / 3)-150, 50, 50), "+")){
			if(numPlayers < maxPlayers)
				numPlayers++;
		}
		if (GUI.Button(new Rect(Screen.width / 2 + 40, (2 * Screen.height / 3)-100, 50, 50), "-")){
			if(numPlayers > minPlayers)
				numPlayers--;
		}

		GUI.Label(new Rect(Screen.width / 2 - (buttonWidth / 2)-40, (2 * Screen.height / 3) - (buttonHeight / 2)-100,100,100), "Players Selected: "+numPlayers);

		if(GUI.Button(buttonRect,"Back")){
			currentMenu = Menus.Main;
		}
		if(GUI.Button(buttonRect2,"Play")){
			gameController.GetComponent<GameController>().numPlayers = numPlayers;
			Application.LoadLevel("LoadingScreen");
		}
	}

	void renderSettings(){

	}
}
