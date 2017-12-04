using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithPlayer : MonoBehaviour {

	public float range = 2.0f;
	public Vector3 dest = Vector3.zero;
	private GameObject player;
	public Vector3 position;
	private float test = 0.3f; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update(){
		position = new Vector3(dest.x-player.transform.position.x,dest.y-player.transform.position.y);
		//position.Normalize ();
		transform.position = Vector3.Lerp(player.transform.position,dest,test);//player.transform.position+position * range;
		test-=0.05f*Time.deltaTime;
	}
}
