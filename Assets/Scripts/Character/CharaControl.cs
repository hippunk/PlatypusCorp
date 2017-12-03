using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaControl : MonoBehaviour {

	// Use this for initialization
	public float speed;
	private Vector3 target = new Vector3();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		//Debug.Log ("hor : "+horizontal+" ver : "+vertical);


		target.x = horizontal;
		target.y = vertical;
		target.Normalize ();

		transform.position += target* Time.deltaTime*speed;
	}

	int ClampFloat(float f){
		return f < 0 ? -1 : f > 0 ? 1 : 0;
	}

}
