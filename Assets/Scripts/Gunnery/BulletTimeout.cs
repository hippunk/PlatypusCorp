using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeout : MonoBehaviour {


	public float time = 100.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time = Mathf.Max(0,time-Time.deltaTime);
		if (time <= 0) {//Détruire la boulette
			
			Destroy(this.gameObject);
		}
	}
}
