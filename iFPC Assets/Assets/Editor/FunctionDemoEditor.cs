using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Reflection;
using System;

[CustomEditor(typeof(FunctionDemo))]
public class FunctionDemoEditor : Editor
{
	static string[] methods;
	static string[] ignoreMethods = new string[] { "Start", "Update" };

	static bool decisionMade = false;

	public enum decision {Nothing, Destroy, StartScene, EndScene, Pause, Play, KillPlayer, ModPlayerHealth, StartDialogue, CallFunction};
	public decision choice = decision.Nothing;
	SerializedObject serObj;







	static FunctionDemoEditor()
	{
		methods =
			typeof(FunctionDemo)
				.GetMethods(BindingFlags.Instance | BindingFlags.Public) // Instance methods, public
				.Where(x => x.DeclaringType == typeof(FunctionDemo)) // Only list methods defined in our own class
				//.Where(x => x.GetParameters().Length == 0) // Make sure we only get methods with zero or one argumenrts
				.Where(x => !ignoreMethods.Any(n => n == x.Name)) // Don't list methods in the ignoreMethods array (so we can exclude Unity specific methods, etc.)
				.Select(x => x.Name)
				.ToArray();
	}


	public override void OnInspectorGUI()
	{

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Select a public function below to call OnCollision.", EditorStyles.largeLabel);
		EditorGUILayout.Space ();

			FunctionDemo obj = target as FunctionDemo;
	
	
			if (obj != null)
			{
				int index;
				
				try
				{
					index = methods
						.Select((v, i) => new { Name = v, Index = i })
							.First(x => x.Name == obj.MethodToCall)
							.Index;
				}
				catch
				{
					index = 0;
				}
	
				if(methods.Length != 0) {
					EditorGUILayout.BeginHorizontal ();
					obj.MethodToCall = methods[EditorGUILayout.Popup(index, methods)];
					if(typeof(FunctionDemo).GetMethod (methods[index]).GetParameters().Length == 1) {
						Type t = typeof(FunctionDemo).GetMethod (methods[index]).GetParameters ().ElementAt (0).ParameterType;
						if(t == typeof(int)) {
							obj.pArgInt = EditorGUILayout.IntField (obj.pArgInt);
							obj.pArgObject = obj.pArgInt;
						}
						if(t == typeof(float)) {
							obj.pArgFloat = EditorGUILayout.FloatField (obj.pArgFloat);
							obj.pArgObject = obj.pArgFloat;
						}
	
						if(t == typeof(string)) {
							obj.pArgString = EditorGUILayout.TextField(obj.pArgString);
							obj.pArgObject = obj.pArgString;
						}
	
						if(t == typeof(bool)) {
							obj.pArgBool = EditorGUILayout.Toggle (obj.pArgBool);
							obj.pArgObject = obj.pArgBool;
						}
					}
					EditorGUILayout.EndHorizontal ();
						//obj.p_arg = EditorGUILayout.ObjectField ((UnityEngine.Object)obj.p_arg, typeof(FunctionDemo).GetMethod (methods[index]).GetParameters ().ElementAt (0).ParameterType);
	
				}
				else {
					EditorGUILayout.LabelField ("No public functions found.");
				}
		}
		}
	


}