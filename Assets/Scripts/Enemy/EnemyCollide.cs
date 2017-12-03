using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour {

	private bool invulnerable = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Collide with bullet
		if (collision.gameObject.tag == "Bullet" && !invulnerable) {
			Bullet bullet = collision.gameObject.GetComponent<Bullet> ();
			if(GetComponent<EnemyLife>()!=null)GetComponent<EnemyLife>().life -= bullet.damage;
			Destroy (collision.gameObject);
		}

		//Polute and link when collide
		if (collision.gameObject.tag == "Player" && !invulnerable) {
			invulnerable = true;
			//GetComponent<MoveToPlayer> ().angularSpeed += 1.0f;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
			EnemyPolute polute = GetComponent<EnemyPolute> ();
			if (polute != null) {
				Debug.Log ("polute");
				polute.polute ();
				Destroy (polute);
			}
		}
	}
}
