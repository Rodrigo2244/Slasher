using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newSlasherAI : MonoBehaviour {
	public NavMeshAgent agent;
	public GameObject[] waypoints;
	public GameObject[] victims;
	public GameObject gameController;
	public Transform currentWaypoint;
	public float walkSpeed;
	public float runSpeed;
	public State state;
	public Transform targetVictim;

	public enum State{
		Roaming,
		Chasing
	};
	
	// Use this for initialization
	void Start(){
		agent = GetComponent<NavMeshAgent>();
		transform.position = waypoints[Random.Range(0,waypoints.Length-1)].transform.position;
		gameController = GameObject.Find("Game Controller");
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		getVictims();
		targetVictim = null;
		getWaypoint();
		agent.speed = walkSpeed;
	}

	// Update is called once per frame
	void Update(){
		Debug.DrawLine(transform.position,currentWaypoint.position,Color.green);
		foreach(GameObject victim in victims){
			if(targetVictim == victim){
				Debug.DrawLine(transform.position,victim.transform.position,Color.red);
			}else{
				Debug.DrawLine(transform.position,victim.transform.position,Color.yellow);
			}

			if(Vector3.Distance(transform.position,victim.transform.position) <= 1){
				Kill(victim);
			}
		}

		switch(state){
			case State.Roaming:
				if(Vector3.Distance(transform.position,currentWaypoint.position) <= 2){
					getWaypoint();
				}
				Search();
			break;
			case State.Chasing:
				ChaseVictim();
			break;
		}
	}

	void getVictims(){
		victims = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
		victims = GameObject.FindGameObjectsWithTag("Player");
		Debug.Log("Got victims");
		if(victims.Length == 0){
			getVictims();
		}
	}

	//Get next roam location
	void getWaypoint(){
		currentWaypoint = waypoints[Random.Range(0,waypoints.Length-1)].transform;
		agent.SetDestination(currentWaypoint.position);
	}

	void Kill(GameObject victim){
		if(victim.CompareTag("Player") && victim.GetComponent<FPSInputController>().win != true){
			int playerId = victim.GetComponent<FPSInputController>().PlayerId;
			gameController.GetComponent<GameController>().HasDied(playerId);
			
			victims = new GameObject[victims.Length];
			victims = GameObject.FindGameObjectsWithTag("Player");
	
			agent.speed = walkSpeed;

			if(victim == targetVictim.gameObject){
				targetVictim = null;
			}
			Destroy(victim);
			
			StopChase();
			getWaypoint();
		}
	}

	void Search(){
		foreach(GameObject victim in victims){
			if(Vector3.Distance(transform.position,victim.transform.position) <= 5 && victim.GetComponent<flashlightMechanic>().isLightOn){
				targetVictim = victim.transform;
				state = State.Chasing;
			}
		}
	}

	void ChaseVictim(){
		agent.speed = runSpeed;
		agent.SetDestination(targetVictim.position);
	}

	void StopChase(){
		state = State.Roaming;
		targetVictim = null;
	}
}