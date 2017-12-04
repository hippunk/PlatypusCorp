using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Bullet : Bullet {

	public Enemy5Bullet(){
		setupTag ("Orange");
	}

	public override void onTouch(GameObject touched){

		Debug.Log ("Enemy5Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().colorTag == recoverTag()) {
			touched.GetComponent<EnemyLife> ().damageLife ();
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<BulletFire> ()
				.reloadCleanBullet (recoverTag ());
		}

	} 
}
