using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithPlayer : MonoBehaviour {

	public float range = 2.0f;
	public Vector3 dest = Vector3.zero;
	private GameObject player;
	public Vector3 position;
	private float test = 1.0f; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update(){
		position = new Vector3(dest.x-player.transform.position.x,dest.y-player.transform.position.y,-3);
		position.Normalize ();
		transform.position = player.transform.position+position * range*test;
		test -= Time.deltaTime*0.05f;
	}
}
