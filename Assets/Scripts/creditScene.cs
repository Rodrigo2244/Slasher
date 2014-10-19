using UnityEngine;
using System.Collections;

public class creditScene : MonoBehaviour {

	public GUIText personName;
	public GUIText description;

	// Use this for initialization
	void Start () {
		StartCoroutine(Credits ());
	}
	
	IEnumerator Credits(){
		yield return new WaitForSeconds(4);
		personName.text = "Rodrigo Rojas-Ferrer";
		description.text = "Lead Designer, Programmer";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Alex Batty";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Eric Fraze";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Sam Heineman";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Ryan Stith";
		description.text = "Level Designer";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Melissa Almirall";
		description.text = "3D Modeler";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Chris Alvarado";
		description.text = "3D Modeler, Animator";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Andrew Connell";
		description.text = "3D Modeler";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		personName.text = "Stephanie Phillips";
		description.text = "2D Artist, Sound Artist";
		yield return new WaitForSeconds(4);
		personName.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);

		Application.LoadLevel(0);
	}
}