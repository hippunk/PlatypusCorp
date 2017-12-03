using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFeedback : MonoBehaviour {
	public BulletFire gun;
	public Image[] childSprite;
	private GameObject[] bulletList;
	private int curBullet;

	// Use this for initialization
	void Start () {
		if (gun) {
			bulletList = gun.bulletList;
			curBullet = gun.curBullet;
		}
	}
	
	// Update is called once per frame
	void Update () {
		populateHUD();
	}

	void populateHUD(){
		if (bulletList.Length > 0){
			for (int childSpriteCount = 0; childSpriteCount < childSprite.Length; ++childSpriteCount) {
				Debug.Log ("child count: " + childSpriteCount);
				Debug.Log("bulletlist count: " + (curBullet + childSpriteCount) % gun.maxBullet);
				childSprite [childSpriteCount].sprite = bulletList [(curBullet + childSpriteCount) % gun.maxBullet]
						.GetComponent<SpriteRenderer> ().sprite;
			}
		}
	}

}
