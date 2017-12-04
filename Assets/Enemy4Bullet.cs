using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Bullet : Bullet {

	public Enemy4Bullet(){
		setupTag ("Purple");
	}

	public override void onTouch(GameObject touched){
		Debug.Log ("Enemy4Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().colorTag == recoverTag()) {
			touched.GetComponent<EnemyLife> ().damageLife ();
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<BulletFire> ()
				.reloadCleanBullet (recoverTag ());
		}

	} 
}
