using UnityEngine;
using System.Collections;

public class slasherAI : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject[] victims;
	public Transform currentWaypoint;
	bool isRoaming;
	bool isChasing;
	int teleportTimer;
	public int teleportTimerLimit;

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
		if(isRoaming){
			if(Vector3.Distance(currentWaypoint.position,transform.position) < 1){
				getWaypoint(Random.Range(0,waypoints.Length));
			}
			GetComponent<NavMeshAgent>().SetDestination(currentWaypoint.position);
		}

		if(teleportTimer == 0){
			Teleport (Random.Range(0,waypoints.Length));
		}
	}

	void getWaypoint(int location){
		if(Vector3.Distance(transform.position,waypoints[location].transform.position) <= 10){
			teleportTimer--; 
			currentWaypoint = waypoints[location].transform;
		}
	}

	void Teleport(int location){
		foreach(GameObject victim in victims){
			if(Vector3.Distance(victim.transform.position,waypoints[location].transform.position)<10 && Vector3.Distance(victim.transform.position,waypoints[location].transform.position)>5){
				transform.position = waypoints[location].transform.position;
				teleportTimer = teleportTimerLimit;
				return;
			}
		}
		Teleport (Random.Range(0,waypoints.Length));
	}
}