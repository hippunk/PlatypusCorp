using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {
	private GameObject target = null;
	public float translationSpeed = 2.0f;
	public float angularSpeed = 2.0f;
	public float correctionOffset = 2.0f;

	public GameObject objDebug;

	private bool evade = false;
	private float correctionAngle = 0;
	// Use this for initialization
	void Start () {
		//objDebug = new GameObject ();
		if (target == null)
			target = GameObject.FindGameObjectWithTag ("Player");
		else {
			Debug.Log ("pb chargement Player");
		}
			Vector3 lookPos = target.transform.position - transform.position;

			transform.rotation = Quaternion.LookRotation (Vector3.forward, lookPos);

	}
	
	// Update is called once per frame
	void Update () {
			Move ();

	}

	void Move(){

		/*float angle = Vector3.SignedAngle (target.transform.position, transform.position, Vector3.forward);

		transform.rotation = Quaternion.Euler (0, 0, angle) * transform.rotation;*/


		Vector3 lookPos = target.transform.position - transform.position;
		if (evade) {
			Debug.Log ("evade");
			if (correctionAngle == 0) {
				correctionAngle += correctionOffset;
			} else {
				correctionAngle += correctionOffset;				
			}

			Transform tmpTarget = target.transform;
			tmpTarget.RotateAround (transform.position, Vector3.forward, correctionAngle);
			//objDebug.transform.position = tmpTarget.position;
			lookPos = tmpTarget.transform.position - transform.position;
		}

		Quaternion rotation = Quaternion.LookRotation(Vector3.forward,lookPos); //Auto target selected enemy
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*angularSpeed);

		transform.rotation.SetLookRotation (target.transform.position);
		transform.Translate (Vector3.up*Time.deltaTime*translationSpeed);
	}
		

	/*void OnCollisionEnter(Collision collision)
	{
		evade = true;
		Debug.Log ("enter collider");
	}
	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("exit collider");
		evade = false;
	}*/
}
