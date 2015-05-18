using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAsync ((int)Random.Range(4.0f,5.0f));
		yield return async;
	}
}
