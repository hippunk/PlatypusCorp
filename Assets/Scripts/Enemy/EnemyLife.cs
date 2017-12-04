using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int life = 1;
	public int score = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0) {
			GameObject.FindGameObjectWithTag ("Score").GetComponent<HUDupdateScore> ().addToScore (score);
			Destroy (this.gameObject);
		}
	}


}
