using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : Bullet {

	public Enemy2Bullet(){
		this.tag = "Red";
	}

	public override void onTouch(GameObject touched){
		Debug.Log ("Enemy2Bullet touch");
		//touched.GetComponent<EnemyLife> ().upgradeLife();
		if (touched.GetComponent<EnemyPolute> ().tag == this.tag) {
			touched.GetComponent<EnemyLife> ().damageLife ();
		}

	}
}
