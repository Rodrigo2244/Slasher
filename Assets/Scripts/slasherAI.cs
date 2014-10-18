using UnityEngine;
using System.Collections;

public class slasherAI : MonoBehaviour {

	GameObject[] waypoints;
	GameObject[] victims;
	Transform currentWaypoint;
	RaycastHit objectSeen;
	bool isRoaming;
	bool isChasing;
	int teleportTimer;

	public int teleportTimerLimit;
	public float lineOfSight;
	public float walkSpeed;
	public float runSpeed;

	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		victims = GameObject.FindGameObjectsWithTag("Player");
		currentWaypoint = waypoints[Random.Range(0,waypoints.Length)].transform;
		getWaypoint(Random.Range(0,waypoints.Length));
		isRoaming = true;
		teleportTimer = teleportTimerLimit;
	}
	
	// Update is called once per frame
	void Update () {
		//Roam aimlessly
		if(isRoaming){
			if(Vector3.Distance(currentWaypoint.position,transform.position) < 1){
				getWaypoint(Random.Range(0,waypoints.Length));
			}
			GetComponent<NavMeshAgent>().SetDestination(currentWaypoint.position);
		}

		//Teleport slasher to new location
		if(teleportTimer == 0){
			Teleport (Random.Range(0,waypoints.Length));
		}

		//Interact with object in his line of sight
		if((Physics.Raycast(transform.position,transform.forward,out objectSeen,lineOfSight) || 
		   Physics.Raycast(transform.position,transform.forward+transform.right,out objectSeen,lineOfSight) ||
		   Physics.Raycast(transform.position,transform.forward-transform.right,out objectSeen,lineOfSight)) && isRoaming){
			if(objectSeen.transform.tag == "Player" && objectSeen.transform.GetComponent<flashlightMechanic>().isLightOn){
				StartCoroutine(Chase (objectSeen.transform.gameObject));
			}
		}

		/*foreach(GameObject victim in victims){
			if(Vector3.Distance(victim.transform.position,transform.position) < 10 && Physics.Raycast(transform.position,)){
			}
		}*/

		Debug.DrawRay(transform.position,transform.forward*lineOfSight,Color.red);
		Debug.DrawRay(transform.position,transform.forward+transform.right*lineOfSight,Color.red);
		Debug.DrawRay(transform.position,transform.forward-transform.right*lineOfSight,Color.red);
		Debug.DrawLine(transform.position,currentWaypoint.position,Color.green);

	}
	
	//Get next roam location
	void getWaypoint(int location){
		if(Vector3.Distance(transform.position,waypoints[location].transform.position) <= 10){
			teleportTimer--; 
			currentWaypoint = waypoints[location].transform;
		}
	}

	void Teleport(int location){
		foreach(GameObject victim in victims){
			if(Vector3.Distance(victim.transform.position,waypoints[location].transform.position)<10 && Vector3.Distance(victim.transform.position,waypoints[location].transform.position)>5){
				GetComponent<NavMeshAgent>().Warp(waypoints[location].transform.position);
				teleportTimer = teleportTimerLimit;
				return;
			}
		}
		Teleport (Random.Range(0,waypoints.Length));
	}

	IEnumerator Chase(GameObject victim){
		isRoaming = false;
		GetComponent<NavMeshAgent>().speed = runSpeed;
		GetComponent<NavMeshAgent>().SetDestination(victim.transform.position);
		yield return 0;
		if(GetComponent<NavMeshAgent>().remainingDistance < 5){
			StartCoroutine(Chase (victim));
		} else {
			isRoaming = true;
			teleportTimer = teleportTimerLimit;
			GetComponent<NavMeshAgent>().speed = walkSpeed;
			yield return 0;
		}
	}

	/*void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player") && other.GetComponent<FPSInputController>().win != true)
			Destroy (other.gameObject);
	}*/
}