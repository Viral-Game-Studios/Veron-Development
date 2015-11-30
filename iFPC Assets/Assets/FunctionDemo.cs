using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class FunctionDemo : MonoBehaviour
{
	//DO NOT MESS WITH THIS
	//-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -
	public GameObject targetObject;
	public Type targetType;
	
	public string MethodToCall;
	public object pArgObject;
	public int pArgInt;
	public float pArgFloat;
	public string pArgString;
	public bool pArgBool;

	private void CallMethod() {
		
		if(pArgObject == null)
			typeof(FunctionDemo).GetMethod (MethodToCall, BindingFlags.Instance | BindingFlags.Public).Invoke (this, new object[0]);
		else
			typeof(FunctionDemo)
				.GetMethod(MethodToCall, BindingFlags.Instance | BindingFlags.Public)
				.Invoke(this, new object[1] {pArgObject});
		
	}

	//-   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -





	//Create your desired methods here.

	public void DebugMessage(string message) {
		Debug.Log (message);
	}


	public void DestroyGameObject() {
		Destroy (gameObject);
	}


	void OnCollisionEnter(Collision col) {
		CallMethod ();
	}




}