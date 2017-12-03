using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletFeedback : MonoBehaviour {
	public BulletFire gun;
	public int nbCard = 10;
	public GameObject card; 


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		populateHUD();
	}

	void populateHUD(){
		if (gun.reload == true) {
			foreach (Transform child in transform) {
				Destroy (child.gameObject);
			}
			Debug.Log ("print");
			for (int i = nbCard-1; i >=0 ; i--) {
				//Debug.Log ("i : "+((i+gun.curBullet)%gun.maxBullet)+"  lim : "+nbCard);
				GameObject tmpCard = Instantiate (card,this.gameObject.transform);
				tmpCard.transform.GetChild(0).GetComponentInChildren<Image> ().sprite = gun.bulletList [(i+gun.curBullet)%gun.maxBullet].GetComponent<SpriteRenderer> ().sprite;
			}

			gun.reload = false;
		}
	}

}
