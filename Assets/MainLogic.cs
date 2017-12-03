using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour {
	public EnemyFactory factory;
	public bool launch = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (launch) {
			launch = false;
			factory.startWorking ();
		}
	}
}
