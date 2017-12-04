using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : Bullet {

	public Enemy3Bullet(){
		setupTag ("Green");
	}

	public override void onTouch(GameObject touched){
		//touched.GetComponent<MoveToPlayer> ().upgradeSpeed ();
		Debug.Log ("Enemy3Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().colorTag == recoverTag()) {
			touched.GetComponent<EnemyLife> ().damageLife ();
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<BulletFire> ()
				.reloadCleanBullet (recoverTag ());
		}

	} 
}
