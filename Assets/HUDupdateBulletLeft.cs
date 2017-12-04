using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDupdateBulletLeft : MonoBehaviour {
	public Text field;
	public Text field2;
	public BulletFire gun;
	private int left;
	// Use this for initialization
	void Start () {
		left = gun.maxBullet;
		field.text = gun.maxBullet + "/" + gun.maxBullet;
		field2.text = gun.maxBullet + "/" + gun.maxBullet;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decreaseBulletCount(){

		if (left > 0) {
			left -= 1;
		}

		field.text = left + "/" + gun.maxBullet;
		field2.text = left + "/" + gun.maxBullet;
	}
}
