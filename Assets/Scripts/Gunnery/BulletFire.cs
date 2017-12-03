using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {


	public float fireRate = 0.2f;
	public int maxBullet = 20;
	public int curBullet = 0;
	public GameObject regularBullet;
	public GameObject dummyBullet;


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

			rofTimer = fireRate;
			Instantiate (bulletList[curBullet],transform.position,transform.rotation);

			curBullet = curBullet+1>=maxBullet?0:curBullet+1;
		}
		
	}
}
