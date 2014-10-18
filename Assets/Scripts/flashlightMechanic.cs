using UnityEngine;
using System.Collections;

public class flashlightMechanic : MonoBehaviour {
	public int PlayerId = 1;
	public Light flashLight;
	public bool isLightOn;
	public AudioSource FlashlightClick;
	bool Held = false;

	// Use this for initialization
	void Start () {
		isLightOn = true;
		flashLight = gameObject.GetComponentInChildren<Light>();
	}

	public IEnumerator Switch () {
		yield return new WaitForSeconds (0.3f);
		isLightOn = !isLightOn;
	}
	
	// Update is called once per frame
	void Update () {
		if(isLightOn){
			flashLight.intensity = 1;
		} else {
			flashLight.intensity = 0;
		}

		if(Input.GetAxis("Flashlight"+PlayerId) == 1 && Held != true){
			FlashlightClick.Play ();
			StartCoroutine("Switch");
			Held = true;
		}
		if(Input.GetAxis("Flashlight"+PlayerId) == 0 ){
			Held = false;
		}
	}
}
