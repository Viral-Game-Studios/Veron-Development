using UnityEngine;
using UnityEditor;
using System.Collections;

public class ActionColliderEditor : Editor {

	SerializedObject serObj;

	SerializedProperty playerTag;
	SerializedProperty loadScene;
	SerializedProperty sceneName;
	SerializedProperty callFunction;
	SerializedProperty functionObject;
	SerializedProperty functionName;

	
	void OnEnable() {

		serObj = new SerializedObject(target);
		playerTag = serObj.FindProperty ("playerTag");

	}

	public override void OnInspectorGUI() {



	}
}
