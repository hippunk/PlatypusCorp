using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropProto : MonoBehaviour {

	public bool overing = false;
	public bool dragging = false;

	private float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && overing) {
			
			Debug.Log ("Drag");
			dragging = true;					
		}	
		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
		if (Input.GetMouseButtonUp(0) && overing) {
			dragging = false;
		}	
	}

	void OnMouseOver()
	{
		if (!overing) {
			//If your mouse hovers over the GameObject with the script attached, output this message
			overing = true;
			Debug.Log ("Mouse is over GameObject.");
			distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		}
	}

	void OnMouseExit()
	{
		if(overing && !dragging){
		//The mouse is no longer hovering over the GameObject so output this message each frame
			overing = false;
			Debug.Log("Mouse is no longer on GameObject.");
		}
	}


}
