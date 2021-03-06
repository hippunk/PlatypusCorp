﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Bullet : MonoBehaviour {
	public string tag;
	public bool hasTouched = false;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		hasTouched = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void setupTag(string value){
		tag = value;
	}

	public string recoverTag(){
		return tag;
	}

	public virtual void onTouch (GameObject touched){
	}

}
