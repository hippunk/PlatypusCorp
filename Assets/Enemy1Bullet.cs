using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : Bullet {

	public Enemy1Bullet(){
		this.tag = "Blue";
	}

	public override void onTouch(GameObject touched){
		//Object blueFieldSrc = Resources.Load();//load ici le blue field
		//GameObject blueField = Instantiate (blueFieldSrc) as GameObject;

		//blueField.transform.position = touched.transform.position;

		Debug.Log ("Enemy1Bullet touch");
		if (touched.GetComponent<EnemyPolute> ().tag == this.tag) {
			touched.GetComponent<EnemyLife> ().damageLife ();
		}

	}
}
