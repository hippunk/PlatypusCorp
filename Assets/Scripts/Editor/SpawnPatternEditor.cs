/*#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SpawnPatterns))]
public class SpawnPatternEditor : Editor  {

	//int oldNumber = 0;
	//
	public override void OnInspectorGUI()
	{
		SpawnPatterns myTarget = (SpawnPatterns)target;

		//SpawnPatterns obj = ScriptableObject.CreateInstance<SpawnPatterns>();
		//SerializedObject serializedObject = new UnityEditor.SerializedObject(obj);

		UnityEditor.SerializedProperty spNb = serializedObject.FindProperty("patternsNumber");
		UnityEditor.SerializedProperty spL = serializedObject.FindProperty("patterns");
		UnityEditor.SerializedProperty spI = serializedObject.FindProperty("value");

		EditorGUILayout.PropertyField(spNb,new GUIContent("Number of patterns : "));

		for (int i = 0; i < myTarget.patternsNumber; i++) {
			GUILayout.BeginHorizontal ();
			EditorGUIUtility.labelWidth = 60.0f;
			EditorGUILayout.PropertyField(spL.GetArrayElementAtIndex(i),new GUIContent("Pattern : "));
			EditorGUIUtility.labelWidth = 50.0f;
			EditorGUILayout.PropertyField(spI.GetArrayElementAtIndex(i),new GUIContent("Value : "));
			GUILayout.EndHorizontal ();
		}
		serializedObject.ApplyModifiedProperties ();


		if (oldNumber != myTarget.patternsNumber) {
			myTarget.patterns = new GameObject[myTarget.patternsNumber];
			myTarget.value = new int[myTarget.patternsNumber];
			//If value changed, then update lists and build ihm
			oldNumber = myTarget.patternsNumber;

		}
	}
}

#endif*/