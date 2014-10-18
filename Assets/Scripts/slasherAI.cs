using UnityEngine;
using System.Collections;

public class slasherAI : MonoBehaviour {

	public GameObject[] waypoints;
	public Transform currentWaypoint;
	bool isRoaming;
	bool isChasing;
	bool isTeleporting;
	int behaviorTimer;

	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		getWaypoint();
		isRoaming = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isRoaming){
			if(Vector3.Distance(currentWaypoint.position,transform.position) < 1){
				getWaypoint();
			}
			GetComponent<NavMeshAgent>().SetDestination(currentWaypoint.position);
		}
	}

	void getWaypoint(){
		currentWaypoint = waypoints[Random.Range(0,waypoints.Length)].transform;
		if(Vector3.Distance(currentWaypoint.position,transform.position) < 1){
			getWaypoint();
		}
	}
}
