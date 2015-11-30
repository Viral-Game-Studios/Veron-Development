using UnityEngine;
using System.Collections;

public class ActionCollider : MonoBehaviour {

	public string playerTag;

	public bool loadScene;
	public string sceneName;
	public bool callFunction;
	public GameObject functionObject;
	public string functionName;
	public string functionParams;

	void OnCollisionEnter(Collision col) {

		if(col.transform.CompareTag (playerTag))
			Debug.Log ("PLAYER HIT!");

	}
}
