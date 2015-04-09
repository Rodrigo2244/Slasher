using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class menuIntro : MonoBehaviour {

	public GameObject Menu;

	// Use this for initialization
	void Start () {
		StartCoroutine(Startup());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Startup(){
		yield return new WaitForSeconds(12);
		Menu.SetActive(true);
		GameObject.Find("MenuEventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Play"));
	}
}
