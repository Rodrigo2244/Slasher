using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool open = false;
	public bool delay = false;
	public GameObject[] players;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Slasher");
	}

	public IEnumerator Open () {
		animation["Door Open"].speed = 1;
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		open = true;
		Debug.Log ("Open");
	}

	public IEnumerator Close () {
		animation ["Door Open"].speed = -1;
		animation.Play("Door Open");
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		open = false;
		Debug.Log ("Closed");
	}
	
	// Update is called once per frame
	void Update () {
		if( (enemy.transform.position - gameObject.transform.position).magnitude <= 2)
		{
			Debug.Log ("Walked through Slasher");
			enemy.GetComponent<slasherAI>().wait = true;
			enemy.GetComponent<slasherAI>().door = gameObject;
			if(open != true)
			{
				StartCoroutine("Open");
			}
		}
		foreach(GameObject player in players)
		{
			if(Input.GetAxis("Flashlight"+player.GetComponent<FPSInputController>().PlayerId) == 1 && delay != true && (player.transform.position - gameObject.transform.position).magnitude <= 2)
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
	void OnTriggerEnter(Collider other)
	{

			

	}
}
