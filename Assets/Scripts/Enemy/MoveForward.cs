using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
	public GameObject target;
	public float TranslationSpeed;
	private bool canMove;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
		canMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove)
			Move ();
		else
			initiateMove ();
	}

	void Move(){
		transform.Translate (direction * Time.deltaTime * TranslationSpeed);
	}

	void initiateMove(){
		canMove = true;
		direction = new Vector3 (0, 0, 0);
		float dirX = (target.transform.position.x - transform.position.x);
		float dirY = (target.transform.position.y - transform.position.y);


		if (dirX == 0f) {
			dirX = 1;
		}
		if (dirY == 0f) {
			dirY = 1;
		}
		direction.x = (target.transform.position.x - transform.position.x) / Mathf.Abs(dirX);
		direction.y = (target.transform.position.y - transform.position.y) / Mathf.Abs(dirY);
	}
}
