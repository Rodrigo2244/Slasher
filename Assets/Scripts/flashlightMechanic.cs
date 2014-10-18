using UnityEngine;
using System.Collections;

public class flashlightMechanic : MonoBehaviour {

	public GameObject flashLight;
	public bool isLightOn;
	bool Held = false;
	// Use this for initialization
	void Start () {
		isLightOn = true;
		flashLight = transform.GetChild(1).GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(isLightOn){
			flashLight.SetActive(true);
		} else {
			flashLight.SetActive(false);
		}

		if(Input.GetAxis("Flashlight"+GetComponentInParent<FPSInputController>().PlayerId) == 1 && Held != true){
			isLightOn = !isLightOn;
			Held = true;
		}
		if(Input.GetAxis("Flashlight"+GetComponentInParent<FPSInputController>().PlayerId) == 0 ){
			Held = false;
		}
	}
}
