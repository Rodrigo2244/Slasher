using UnityEngine;
using System.Collections;

public class introMatinee : MonoBehaviour {

	public GameObject gui;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(animation.isPlaying == false){
			gui.SetActive(true);
		}
	}
}
