﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

	public HUDupdateBulletLeft hud;
	public HUDupdateScore score;
	public float fireRate = 0.2f;
	public int maxBullet = 20;
	public int curBullet = 0;
	public GameObject regularBullet;
	public GameObject dummyBullet;
	public bool reload = true;
	public int iPol = 0;

	private float rofTimer;
	public GameObject[] bulletList;




	// Use this for initialization
	void Start () {
		rofTimer = fireRate;
		bulletList = new GameObject[maxBullet];
		for(int i = 0;i<maxBullet;i++){
			bulletList[i] = regularBullet;
		}
	}
	
	// Update is called once per frame
	void Update () {


		rofTimer = (rofTimer<=0)?0:rofTimer-Time.deltaTime; //Timer between attacks


		if (Input.GetMouseButton(0) && rofTimer <= 0) {
			reload = true;
			rofTimer = fireRate;
			GameObject bullet = Instantiate (bulletList[curBullet],transform.position,transform.rotation) as GameObject;
			//bullet.regBullet = regularBullet;
			
			curBullet = curBullet+1>=maxBullet?0:curBullet+1;
		}
	
		if (iPol >= maxBullet) {
			Debug.Log ("GameOver");
			score.stopScore ();
		}
	}

	public int GetRandomUninfectedBulletID(){

		List<int> uninfectedBullets = new List<int>();
		for(int i = 0;i<bulletList.Length;i++) {
			if (bulletList[i] == regularBullet) {
				uninfectedBullets.Add (i);
			}
		}
		if (uninfectedBullets.Count == 0) {
			return -1;
		}

		return uninfectedBullets[Random.Range(0,uninfectedBullets.Count)];	
	}

	public void reloadCleanBullet(string colorType){
		int i = bulletList.Length;

		Debug.Log ("reloading bullet");
		while (--i >= 0){
			if (bulletList [i].GetComponent<Bullet>().recoverTag() == colorType) {
				bulletList [i] = regularBullet;
				hud.recoverBullet ();
				reload = false;
				return;
			}
		}
		Debug.Log ("Failed To reload");
	}
}
