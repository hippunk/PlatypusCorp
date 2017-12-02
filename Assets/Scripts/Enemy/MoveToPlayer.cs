using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
	private GameObject target;
	public float translationSpeed = 2.0f;
	public float angularSpeed = 2.0f;

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player");

			Vector3 lookPos = target.transform.position - transform.position;
			transform.rotation = Quaternion.LookRotation (Vector3.forward, lookPos);

	}
	
	// Update is called once per frame
	void Update () {
		if (target)
			Move ();
	}

	void Move(){

		/*float angle = Vector3.SignedAngle (target.transform.position, transform.position, Vector3.forward);

		transform.rotation = Quaternion.Euler (0, 0, angle) * transform.rotation;*/


		Vector3 lookPos = target.transform.position - transform.position;

		Quaternion rotation = Quaternion.LookRotation(Vector3.forward,lookPos); //Auto target selected enemy
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*angularSpeed);

		transform.rotation.SetLookRotation (target.transform.position);
		transform.Translate (Vector3.up*Time.deltaTime*translationSpeed);
	}
}
