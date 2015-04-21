using UnityEngine;
using System.Collections;

public class playerID : MonoBehaviour {

	public int ID;
	public finishState finish;

	public enum finishState{
		neither,
		win,
		lose
	}
}