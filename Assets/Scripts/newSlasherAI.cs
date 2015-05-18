using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class newSlasherAI : MonoBehaviour {
 	public NavMeshAgent agent;
	public List<GameObject> waypoints;
	public List<GameObject> victims;
	public GameObject gameController;
	public Transform currentWaypoint;
	public float walkSpeed;
	public float runSpeed;
	public State state;
    public Transform targetVictim;

	public enum State{
		Roaming,
		Chasing,
		Idle
	};
	
	// Use this for initialization
	void Start(){
		getVictims();
		agent = GetComponent<NavMeshAgent>();
		gameController = GameObject.Find("Game Controller");
		foreach(GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint")){
			waypoints.Add(waypoint);
		}
		agent.Warp(waypoints[Random.Range(0,waypoints.Count)].transform.position);
		getWaypoint();
		targetVictim = null;
		agent.speed = walkSpeed;
	}

	// Update is called once per frame
	void Update(){
		//Draw Lines
		if(state == State.Roaming){
			Debug.DrawLine(transform.position,currentWaypoint.position,Color.green);
		}

		foreach(GameObject victim in victims){
			if(victim != null){
				if(victim.GetComponent<playerID>().finish == playerID.finishState.neither){
					Debug.DrawLine(transform.position,victim.transform.position,Color.yellow);
				}
			}
		}

		//Behavior
		switch (state){
			case State.Idle:
			break;
			case State.Roaming:
				Search();
			break;
			case State.Chasing:
				if(targetVictim != null){
					ChaseVictim();
				} else {
					state = State.Roaming;
				}
			break;
		}

		//Kill
		foreach(GameObject victim in victims){
			if(victim != null && Vector3.Distance(transform.position,victim.transform.position) < 1 && victim.GetComponent<playerID>().finish == playerID.finishState.neither){
				Kill(victim);
			}
		}
	}

	void getVictims(){
		foreach(GameObject victim in GameObject.FindGameObjectsWithTag("Player")){
			victims.Add(victim);
		}
	}

	//Get next roam location
	void getWaypoint(){
		currentWaypoint = waypoints[Random.Range(0,waypoints.Count-1)].transform;
		agent.SetDestination(currentWaypoint.position);
	}

	void Kill(GameObject victim){
		victim.GetComponent<playerID>().finish = playerID.finishState.lose;
		targetVictim = null;
		StopChase();
	}

	void Search(){
		foreach(GameObject victim in victims){
			if(Vector3.Distance(transform.position,victim.transform.position) < 5 && victim.GetComponent<playerID>().finish == playerID.finishState.neither){
				targetVictim = victim.transform;
				state = State.Chasing;
				return;
			}
		}

		if(Vector3.Distance(transform.position,currentWaypoint.position)<=1){
			getWaypoint();
		}
	}

	void ChaseVictim(){
		agent.speed = runSpeed;
		agent.SetDestination(targetVictim.position);
	}

	void StopChase(){
		targetVictim = null;
		state = State.Roaming;
		agent.speed = walkSpeed;
		getWaypoint();
	}
}