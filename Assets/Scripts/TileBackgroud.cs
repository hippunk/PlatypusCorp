using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBackgroud : MonoBehaviour {


	public GameObject background;

	// Use this for initialization
	void Start () {

		}
	
	// Update is called once per frame
	void Update () {

		//Get camera size
		float vertExtent = Camera.main.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		Debug.Log (Camera.main.transform.position.x + horzExtent);


		
	}
}
