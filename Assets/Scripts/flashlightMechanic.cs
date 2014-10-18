using UnityEngine;
using System.Collections;

public class flashlightMechanic : MonoBehaviour {
	public int PlayerId = 1;
	public Light flashLight;
<<<<<<< HEAD
<<<<<<< HEAD
	public bool isLightOn;
	public AudioSource FlashlightClick;
=======
	public bool isLightOn = true;
>>>>>>> 4ab5cd7313e7525c90d480ec44f88f45e604be25
=======
	public bool isLightOn = true;
>>>>>>> 8d1eba086336b6824613153a736f974f967f907e
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
