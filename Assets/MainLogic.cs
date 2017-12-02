using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour {
	public GameObject test;
	public EnemyFactory factory;
	public bool launch;
	// Use this for initialization
	void Start () {
		launch = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (launch) {
			Debug.Log ("Launched test");
			factory.generate (test);
			launch = false;
		}
	}
}
