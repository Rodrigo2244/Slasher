using UnityEngine;
using System.Collections;

public class slasherAI : MonoBehaviour {

	GameObject[] waypoints;
	public GameObject[] victims;
	public GameObject gameController;
	Transform currentWaypoint;
	RaycastHit objectSeen;
	bool isRoaming;
	bool isChasing;
	int teleportTimer;
	public float idleTime = 0;
	public int teleportTimerLimit;
	public float lineOfSight;
	public float walkSpeed;
	public float runSpeed;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find("Game Controller");
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		victims = GameObject.FindGameObjectsWithTag("Player");
		currentWaypoint = waypoints[Random.Range(0,waypoints.Length)].transform;
		getWaypoint(Random.Range(0,waypoints.Length));
		isRoaming = true;
		Teleport(Random.Range (0,waypoints.Length));
		teleportTimer = teleportTimerLimit;
	}
	void FixedUpdate (){
		foreach(GameObject victim in victims){
			Debug.DrawLine(transform.position,victim.transform.position,Color.red);
			if(Physics.Raycast(transform.position,victim.transform.position-transform.position,out objectSeen,200))
			{
				if (objectSeen.transform.tag == "Player" && objectSeen.transform.GetComponent<flashlightMechanic>().isLightOn){
					StartCoroutine(Chase (objectSeen.transform.gameObject));
				}
			}

			if ( (victim.transform.position - transform.position).magnitude < 12 )
			{
				if ( victim.transform.tag == "Player" && victim.transform.GetComponent<CharacterMotor>.sprinting ){
					StartCoroutine(Chase (victim.transform.gameObject));
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		//Roam aimlessly
		if(isRoaming){
			idleTime += Time.deltaTime;
			GetComponent<NavMeshAgent>().speed = walkSpeed;
			if(Vector3.Distance(currentWaypoint.position,transform.position) < 1){
				getWaypoint(Random.Range(0,waypoints.Length));
			}
			GetComponent<NavMeshAgent>().SetDestination(currentWaypoint.position);
			if(idleTime >= 200f)
			{
				getWaypoint(Random.Range(0,waypoints.Length));
			}
		}

		//Teleport slasher to new location
		if(teleportTimer == 0){
			Teleport (Random.Range(0,waypoints.Length));
		}


		RaycastHit hit = new RaycastHit();
		CapsuleCollider caspule = GetComponent("CapsuleCollider") as CapsuleCollider;
		Vector3 p1  = transform.position + caspule.center + Vector3.up * (-caspule.height*0.5f);
		Vector3 p2 = p1 + Vector3.up * caspule.height;

		if ( Physics.CapsuleCast(p1, p2, caspule.radius, transform.forward, out hit, 0.1f ) ) {
			Debug.Log ("Fail");
			GameObject deadvictim = hit.collider.transform.gameObject;
			if(deadvictim.CompareTag("Player") && deadvictim.GetComponent<FPSInputController>().win != true)
			{
				int playerId = deadvictim.GetComponent<FPSInputController>().PlayerId;
				gameController.GetComponent<GameController>().HasDied(playerId);
				
				
				deadvictim.tag = "dead";
				
				victims = new GameObject[victims.Length -1];
				victims = GameObject.FindGameObjectsWithTag("Player");
				
				isRoaming = true;
				GetComponent<NavMeshAgent>().speed = walkSpeed;
				
				Destroy (deadvictim.gameObject);
			}

		}

		//Interact with object in his line of sight
		/*if(|| 
		   Physics.Raycast(transform.position,transform.forward+transform.right,out objectSeen,lineOfSight) ||
		   Physics.Raycast(transform.position,transform.forward-transform.right,out objectSeen,lineOfSight)) && isRoaming){

		}*/


			
			//if(Vector3.Distance(victim.transform.position,transform.position) < 10 && Physics.Raycast(transform.position,-(transform.position+victim.transform.position).normalized)){
			//}


	//	Debug.DrawRay(transform.position,transform.forward*lineOfSight,Color.red);
		//Debug.DrawRay(transform.position,transform.forward+transform.right*lineOfSight,Color.red);
		//Debug.DrawRay(transform.position,transform.forward-transform.right*lineOfSight,Color.red);
		//Debug.DrawRay(transform.position,(transform.position+victims[0].transform.position).normalized,Color.blue);
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
		for (int i = 0; i < 5; i++) {
			foreach(GameObject victim in victims){
				if(Vector3.Distance(victim.transform.position,waypoints[location].transform.position)<20 && Vector3.Distance(victim.transform.position,waypoints[location].transform.position)>5){
					GetComponent<NavMeshAgent>().Warp(waypoints[location].transform.position);
					teleportTimer = teleportTimerLimit;
					return;
				}
			}
		}

		location = Random.Range (0, waypoints.Length);
		GetComponent<NavMeshAgent>().Warp(waypoints[location].transform.position);
		teleportTimer = teleportTimerLimit;
		return;
	}

	IEnumerator Chase(GameObject victim){
		if(isRoaming){
			isRoaming = false;
			yield return new WaitForSeconds(1);
		}
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
	/*
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player") && other.GetComponent<FPSInputController>().win != true)
		{
			int playerId = other.GetComponent<FPSInputController>().PlayerId;
			gameController.GetComponent<GameController>().HasDied(playerId);


			other.tag = "dead";

			victims = new GameObject[victims.Length -1];
			victims = GameObject.FindGameObjectsWithTag("Player");

			isRoaming = true;
			GetComponent<NavMeshAgent>().speed = walkSpeed;

			Destroy (other.gameObject);

		}
			
	}*/
}