using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int life = 1;
	public int score = 100;
	private bool upgraded;
	public GameObject spriteBundle;
	public float ttlOutScreen = 5.0f;
	public int outScreenRange = 13;

	private float spawnedTime;
	private GameObject myCamera;
	//public AudioSource audio;

	// Use this for initialization
	void Start () {
		upgraded = false;
		spawnedTime = Time.time;
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (spriteBundle.activeInHierarchy == false)
			spriteBundle.SetActive (true);
		if (life <= 0) {
			//audio.Play();
			GameObject.FindGameObjectWithTag ("Score").GetComponent<HUDupdateScore> ().addToScore (score);

			GameObject.FindGameObjectWithTag ("Player").GetComponent<SFXEngine> ().playSFXKill ();
			Destroy (this.gameObject);


			spriteBundle.SetActive(true);
		}

		if (Vector2.Distance (myCamera.transform.position, transform.position) > outScreenRange) {
			if (Time.time - spawnedTime > ttlOutScreen) {
				getDestroyed ();
			}
		}

	}

	public void damageLife(){
		life -= 1;

		spriteBundle.SetActive (false);
	}

	public void upgradeLife(){
		if (upgraded == false) {
			life += 1;
			upgraded = true;
			this.gameObject.transform.localScale *= 2;
		}
	}

	public void getDestroyed(){
		
		Destroy (this.gameObject);
	}


}
