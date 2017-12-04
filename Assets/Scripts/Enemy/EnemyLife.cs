using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int life = 1;
	public int score = 100;
	private bool upgraded;

	// Use this for initialization
	void Start () {
		upgraded = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0) {
			GameObject.FindGameObjectWithTag ("Score").GetComponent<HUDupdateScore> ().addToScore (score);
			Destroy (this.gameObject);
		}
	}

	public void damageLife(){
		life -= 1;
	}

	public void upgradeLife(){
		if (upgraded == false) {
			life += 1;
			upgraded = true;
			this.gameObject.transform.localScale *= 2;
		}
	}


}
