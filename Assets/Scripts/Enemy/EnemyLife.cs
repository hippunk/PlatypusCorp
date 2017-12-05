using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int life = 1;
	public int score = 100;
	private bool upgraded;
	public GameObject spriteBundle;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		upgraded = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (spriteBundle.activeInHierarchy == false)
			spriteBundle.SetActive (true);
		if (life <= 0) {
			//audio.Play();
			GameObject.FindGameObjectWithTag ("Score").GetComponent<HUDupdateScore> ().addToScore (score);
			Destroy (this.gameObject);

			spriteBundle.SetActive(true);
		}
	}

	public void damageLife(){
		life -= 1;
		if (life <= 0) {
			audio.Play ();
		}
		spriteBundle.SetActive (false);
	}

	public void upgradeLife(){
		if (upgraded == false) {
			life += 1;
			upgraded = true;
			this.gameObject.transform.localScale *= 2;
		}
	}


}
