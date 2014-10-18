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
		StartCoroutine(getVictims());
	}
	
	// Update is called once per frame
	void Update () {
		if(!isPursuing){
			GetComponent<NavMeshAgent>().SetDestination(closestVictim.position);
		}
	}

	IEnumerator getVictims(){
		foreach(GameObject victim in victims){
			if(){
			}
		}
	}
}
