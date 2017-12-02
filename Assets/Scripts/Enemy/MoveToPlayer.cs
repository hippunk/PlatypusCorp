using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
	public GameObject target;
	public float TranslationSpeed;
	public float AngularSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		transform.Translate (transform.right * Time.deltaTime * TranslationSpeed);

		float angle = Vector3.SignedAngle (target.transform.position, transform.position, Vector3.forward);

		transform.rotation = Quaternion.Euler (0, 0, angle) * transform.rotation;
	}
}
