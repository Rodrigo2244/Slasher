using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAsync (3);
		yield return async;
	}
}
