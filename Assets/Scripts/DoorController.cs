using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public bool open = false;
	public bool delay = false;
	public GameObject[] players;
	public GameObject enemy;
	public AudioSource doorClose;
	public AudioSource doorOpen;
	RaycastHit[] hit;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		enemy = GameObject.FindGameObjectWithTag("Slasher");

		//StartCoroutine("Open");

	}

	public IEnumerator Open () {
		animation["Door Open"].speed = 1;
		animation ["Door Open"].time = animation ["Door Open"].length;
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
	void FixedUpdate () {
		players = GameObject.FindGameObjectsWithTag("Player");

		if( (enemy.transform.position - gameObject.transform.position).magnitude <= 2)
		{
			Debug.Log ("Walked through Slasher");
			enemy.GetComponent<slasherAI>().wait = true;
			enemy.GetComponent<slasherAI>().door = gameObject;
			delay = true;
			if(open != true)
			{
				StartCoroutine("Open");
			}
			else
			{
				StartCoroutine ("Close");
				enemy.GetComponent<slasherAI>().wait = false;
			}
		}
		foreach(GameObject player in players)
		{
			if(Input.GetAxis("Door"+player.GetComponent<FPSInputController>().PlayerId) == 1 && delay != true && (transform.position - player.transform.position).magnitude <= 25)
			{
				Debug.Log ("Pressed open door");
				//hit = Physics.CapsuleCastAll(gameObject.transform.position, gameObject.GetComponent<BoxCollider>().center + Vector3.up * (15*0.5f), 10, transform.right, 10f);
				//foreach(RaycastHit hitThing in hit)
				//{
					//Debug.Log (hitThing.collider.gameObject.name);
					////if(hitThing.collider.gameObject == player)
					//{
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
					//}
				//}

			}
			else if(Input.GetAxis("Door"+player.GetComponent<FPSInputController>().PlayerId) == 1 && delay != true && (transform.position - player.transform.position).magnitude > 20)
			{
				Debug.Log ((transform.position - player.transform.position).magnitude);
			}
		}
		
	}
	void OnTriggerEnter(Collider other)
	{

			

	}
}
