using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour {

	private bool invulnerable = false;
	private float ghostTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (invulnerable) {
			if (Time.time - ghostTime >= 60.0f) {
				Destroy (this.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Collide with bullet
		if (collision.gameObject.tag == "Bullet" && !invulnerable) {
			Bullet bullet = collision.gameObject.GetComponent<Bullet> ();

			if (bullet.hasTouched == false) {
				bullet.hasTouched = true;
				EnemyLife enemyLife = GetComponent<EnemyLife> ();
				Debug.Log ("bullet touch");

				PollutedBullet tmpbullet = collision.gameObject.GetComponent<PollutedBullet> ();
				if (tmpbullet != null)
					tmpbullet.applyBulletEffect (this.gameObject);
				else if (enemyLife) {
					enemyLife.damageLife ();

				}
				Destroy (collision.gameObject);
			}

		}

		//Polute and link when collide
		if (collision.gameObject.tag == "Player" && !invulnerable) {
			invulnerable = true;
			ghostTime = Time.time;

			//GetComponent<MoveToPlayer> ().angularSpeed += 1.0f;
			Color grey = new Color();
			grey = Color.gray;
			grey.a = 0.25f;
			foreach (SpriteRenderer elem in gameObject.GetComponentsInChildren<SpriteRenderer> ()){
				elem.color = grey;
			}
			EnemyPolute polute = GetComponent<EnemyPolute> ();
			if (polute != null) {
				//Debug.Log ("polute");
				polute.polute ();
				Destroy (polute);
			}
		}
	}
}
