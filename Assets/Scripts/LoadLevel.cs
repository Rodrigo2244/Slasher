using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAsync (Random.Range (2,Application.levelCount);
		yield return async;
	}
}
