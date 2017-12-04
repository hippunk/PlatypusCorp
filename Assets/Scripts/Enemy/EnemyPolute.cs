using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPolute : MonoBehaviour {
	public string colorTag;
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
		int id = target.GetRandomUninfectedBulletID ();
		if (id != -1) {
			target.bulletList [id] = bullet;
			target.reload = true;
			target.iPol++;
			Debug.Log ("polute");
			target.hud.decreaseBulletCount ();
	
		}
	}
}
