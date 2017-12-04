using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Bullet : Bullet {

	public Enemy5Bullet(){
		this.tag = "Orange";
	}

	public override void onTouch(GameObject touched){

		Debug.Log ("Enemy5Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().tag == this.tag) {
			touched.GetComponent<EnemyLife> ().damageLife ();
		}

	} 
}
