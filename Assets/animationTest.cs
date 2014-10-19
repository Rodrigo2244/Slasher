using UnityEngine;
using System.Collections;

public class animationTest : MonoBehaviour {

	private Animation _animation;

	// Use this for initialization
	void Start () {
		_animation = transform.GetChild(0).GetComponent<Animation>();
		_animation.Play("Take 001");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
