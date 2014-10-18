using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAsync ("GameScene");
		yield return async;
	}
}
