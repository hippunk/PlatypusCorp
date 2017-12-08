using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour {
	private float movedTime;
	private GameObject target;
	private Vector3 movement;
	private bool isMoving;

	public float angularSpeed;
	public float translationSpeed;
	public float aimTime;
	public float dashTime;

	void Start(){
		movedTime = Time.time;
		target = GameObject.FindGameObjectWithTag ("Player");
		movement = new Vector3(0.0f, 0.0f, 0.0f);
		isMoving = false;
	}

	void Update(){
		if (isMoving) {
			Move ();
		} else
			Aim ();
	}

	void Aim(){
		Vector3 lookPos = target.transform.position - transform.position;

		transform.rotation.SetLookRotation (target.transform.position);
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward,lookPos);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime* angularSpeed);


		transform.rotation.SetLookRotation (target.transform.position);
		if (Time.time - movedTime > aimTime) {
			isMoving = true;
			movedTime = Time.time;
		}
	}

	void Move(){
		transform.Translate (Vector3.up*Time.deltaTime*translationSpeed);
		if (Time.time - movedTime > dashTime) {
			isMoving = false;
			movedTime = Time.time;
		}
	}
}
