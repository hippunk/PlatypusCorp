using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Collide with bullet
		Debug.Log ("Collide");
		if (collision.gameObject.tag == "Bullet") {
			Bullet bullet = collision.gameObject.GetComponent<Bullet> ();
			if(GetComponent<EnemyLife>()!=null)GetComponent<EnemyLife>().life -= bullet.damage;
			Destroy (collision.gameObject);
		}

		//Polute and link when collide
		if (collision.gameObject.tag == "Player") {
			EnemyPolute polute = GetComponent<EnemyPolute> ();
			if (polute != null) {
				Debug.Log ("polute");
				polute.polute ();
				Destroy (polute);
			}
		}
	}
}
