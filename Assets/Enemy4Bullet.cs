using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Bullet : Bullet {

	public Enemy4Bullet(){
		this.tag = "Purple";
	}

	public override void onTouch(GameObject touched){
		Debug.Log ("Enemy4Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().tag == this.tag) {
			touched.GetComponent<EnemyLife> ().damageLife ();
		}

	} 
}
