using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	private SpriteRenderer background;
	private GameObject mainCamera;

	private float centerPointX;
	private float centerPointY;
	private Vector3 marginX;
	private Vector3 marginY;

	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		background = transform.gameObject.GetComponent<SpriteRenderer> ();

		marginX = new Vector3(Mathf.Round(background.sprite.bounds.extents.x), 0.0f, 0.0f);
		marginY = new Vector3(0.0f, Mathf.Round(background.sprite.bounds.extents.y), 0.0f);

		Debug.Log ("margins: " + marginX.x + "/" + marginY.y);

		centerPointX = 0.0f;//mainCamera.transform.position.x;
		centerPointY = 0.0f;//mainCamera.transform.position.y;
	}

	void FixedUpdate () {
		if (mainCamera.transform.position.x > centerPointX + marginX.x)
			translateToRight ();
		else if (mainCamera.transform.position.x < centerPointX - marginX.x)
			translateToLeft ();
		
		if (mainCamera.transform.position.y > centerPointY + marginY.y)
			translateToUp ();
		else if (mainCamera.transform.position.y < centerPointY - marginY.y)
			translateToDown ();
	}

	void translateToRight(){
		transform.Translate (marginX);
		centerPointX += marginX.x;
	}
	void translateToLeft(){
		transform.Translate(marginX * -1);
		centerPointX -= marginX.x;
	}

	void translateToUp(){
		transform.Translate( marginY);
		centerPointY += marginY.y;
	}

	void translateToDown(){
		transform.Translate(marginY * -1);
		centerPointY -= marginY.y;
	}
}
