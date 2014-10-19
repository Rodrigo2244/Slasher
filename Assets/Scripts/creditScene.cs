using UnityEngine;
using System.Collections;

public class creditScene : MonoBehaviour {

	public GUIText name;
	public GUIText description;

	// Use this for initialization
	void Start () {
		StartCoroutine(Credits ());
	}
	
	IEnumerator Credits(){
		yield return new WaitForSeconds(4);
		name.text = "Rodrigo Rojas-Ferrer";
		description.text = "Creative Lead";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Stephanie Phillips";
		description.text = "2D Artist, Sound Artist";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Sam Heineman";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Alex Batty";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Melissa Almirall";
		description.text = "3D Modeler";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Chris Alvarado";
		description.text = "3D Modeler, Animator";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Ryan Stith";
		description.text = "Level Designer";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Eric Fraze";
		description.text = "Programmer";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		name.text = "Andrew Connell";
		description.text = "3D Modeler";
		yield return new WaitForSeconds(4);
		name.text = "";
		description.text = "";
		yield return new WaitForSeconds(4);
		Application.LoadLevel(0);
	}
}
