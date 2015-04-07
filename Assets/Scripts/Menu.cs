using UnityEngine;
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
		Screen.showCursor = true;
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
		Matrix4x4 svMat = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity,new Vector3(Screen.width/1061f,Screen.height/597f,1f));

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

		GUI.matrix = svMat;
	}

	void renderMain(){
		buttonRect = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2)-140, menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597/ 3) - (buttonHeight / 2)-70, menuButtonWidth, buttonHeight);
		buttonRect3 = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect4 = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2)+70, menuButtonWidth, buttonHeight);
		
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
		buttonRect = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2)+100, menuButtonWidth, buttonHeight);

		if (GUI.Button(new Rect(1061 /2 +200, 597 / 2, 300, 50), "More Victims",buttons)){
			if(numPlayers < maxPlayers)
				numPlayers++;
		}
		if (GUI.Button(new Rect(1061 / 2 -450, 597 / 2, 300, 50), "Less Victims",buttons)){
			if(numPlayers > minPlayers)
				numPlayers--;
		}

		GUI.Label(new Rect(1061 / 2-50, 597 /2-50,100,100), "Players Selected: "+numPlayers, normal);

		
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
		buttonRect = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2), menuButtonWidth, buttonHeight);
		buttonRect2 = new Rect(1061 / 2 - (menuButtonWidth / 2), (2 * 597 / 3) - (buttonHeight / 2)+100, menuButtonWidth, buttonHeight);
		
		masterVol = GUI.HorizontalSlider(new Rect(1061/2-50, 597/2-30, 150, 25), masterVol, 0.0f, 1.0f);
		GUI.Label(new Rect(1061/2-50, 597/2-75, 150,60), "Master Volume: " + (masterVol*100).ToString("f0"),normal);

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
