using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {



	public float velocity = 2f; //Here velocity depends on weapons



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

			transform.Translate (Vector3.up*Time.deltaTime*velocity);
	}

}
