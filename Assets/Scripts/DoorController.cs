using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool open = false;
	public bool delay = false;
	public GameObject[] players;
	public GameObject enemy;
	public AudioSource doorClose;
	public AudioSource doorOpen;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Slasher");

		StartCoroutine("Open");

	}

	public IEnumerator Open () {
		animation["Door Open"].speed = 1;
		animation.Play("Door Open");
		doorOpen.Play ();
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		open = true;
	}

	public IEnumerator Close () {
		animation ["Door Open"].speed = -1;
		animation ["Door Open"].time = animation ["Door Open"].length;
		animation.Play("Door Open");
		doorClose.Play ();
		yield return new WaitForSeconds( animation["Door Open"].length );
		delay = false;
		open = false;
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
					Debug.Log ("Closed");
					StartCoroutine("Close");

				}
				else
				{
					Debug.Log ("Open");
					StartCoroutine("Open");
				}
			}
		}
		
	}
	void OnTriggerEnter(Collider other)
	{

			

	}
}
