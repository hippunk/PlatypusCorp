using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : Bullet {
	public AudioSource fireSound;
	// Use this for initialization
	void Start () {
		fireSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
