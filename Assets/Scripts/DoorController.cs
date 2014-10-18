using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool open = false;
	

	// Use this for initialization
	void Start () {

	}

	public IEnumerator Open () {
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		open = true;
		Debug.Log ("Open");
	}

	public IEnumerator Close () {
		animation ["Door Open"].speed = -1;
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		open = false;
		Debug.Log ("Closed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
