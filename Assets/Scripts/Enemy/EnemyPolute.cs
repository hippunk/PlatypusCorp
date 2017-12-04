using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPolute : MonoBehaviour {

	public float poluteRate = 1.0f;
	public GameObject bullet;

	private BulletFire target = null;

	// Use this for initialization
	void Start () {
		if (target == null) {
			
			target = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<BulletFire> ();
			//Debug.Log ("loaded : " + target);
		}
		else {
			Debug.Log ("pb chargement Player");
		}
	}
	
	public void polute(){
		target.bulletList[target.GetRandomUninfectedBulletID ()] = bullet;
		target.reload = true;
		//target.hud.decreaseBulletCount ();
	}
}
