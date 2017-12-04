using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutedBullet : MonoBehaviour {
	public AudioSource fireSound;
	public Bullet bullet;
	// Use this for initialization
	void Start () {
		fireSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void applyBulletEffect(GameObject target){
	
		bullet.onTouch (target);
	}

}
