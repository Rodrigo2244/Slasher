using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAsync ((int)Random.Range(5.0f,7.0f));
		yield return async;
	}
}
