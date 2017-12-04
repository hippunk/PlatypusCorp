using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : Bullet {

	public Enemy2Bullet(){
		setupTag ("Red");
	}

	public override void onTouch(GameObject touched){
		Debug.Log ("Enemy2Bullet touch");
		//touched.GetComponent<EnemyLife> ().upgradeLife();
		if (touched.GetComponent<EnemyPolute> ().colorTag == recoverTag()) {
			touched.GetComponent<EnemyLife> ().damageLife ();
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<BulletFire> ()
				.reloadCleanBullet (recoverTag ());
		}

	}
}
