using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int life = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0)
			Destroy (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("Collide");
		if (collision.gameObject.tag == "Bullet") {
			Bullet bullet = collision.gameObject.GetComponent<Bullet> ();
			life -= bullet.damage;
			Destroy (collision.gameObject);
		}
	}
}
