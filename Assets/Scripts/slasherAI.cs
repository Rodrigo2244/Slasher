using UnityEngine;
using System.Collections;

public class slasherAI : MonoBehaviour {

	public GameObject[] victims;
	public Transform closestVictim;
	public bool isPursuing;

	// Use this for initialization
	void Start () {
		victims = GameObject.FindGameObjectsWithTag("Player");
		closestVictim = victims[Random.Range(0,victims.Length)].transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isPursuing){
			GetComponent<NavMeshAgent>().SetDestination(closestVictim.position);
		}
	}
}
