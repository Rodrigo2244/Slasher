using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool open = false;
	public bool delay = false;
	public GameObject[] players;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
	}

	public IEnumerator Open () {
		animation["Door Open"].speed = 1;
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		Debug.Log ("Open");
	}

	public IEnumerator Close () {
		animation ["Door Open"].speed = -1;
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		Debug.Log ("Closed");
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject player in players)
		{
			if(Input.GetAxis("Flashlight"+player.GetComponent<FPSInputController>().PlayerId) == 1 && delay != true && Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2)
			{
				delay = true;
				if(open)
				{
					open = false;
					StartCoroutine("Close");
					Debug.Log ("Actually Did something");

				}
				else
				{
					open = true;
					StartCoroutine("Open");

				}
			}
		}
		
	}
	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetAxis("Flashlight"+other.GetComponent<FPSInputController>().PlayerId) == 1)
			{

				
			}
		}
	}
}
