﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaLookAtMouse : MonoBehaviour {

	public Vector3 lookPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) { //Dirty pause handling
			Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			diff.Normalize ();

			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (0f, 0f, rot_z - 90);
	
		}
	}
}
