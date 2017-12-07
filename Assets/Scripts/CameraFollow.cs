using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public GameObject target;
	public float speed = 2.0f;
	public float rangeX = 0.5f;
	public float rangeY = 0.5f;
	public int ihmSize = 170;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float vertExtent = Camera.main.orthographicSize;    
		//float horzExtent = vertExtent * Screen.width / Screen.height;

		//Définition limite du monde
		/*float Olim = wl.transform.position.x - wl.bounds.size.x / 2  + 0.01f;
		float Elim = wl.transform.position.x + wl.bounds.size.x / 2 - 0.01f;
		float Slim = wl.transform.position.y - wl.bounds.size.y / 2 + 0.01f;
		float Nlim = wl.transform.position.y + wl.bounds.size.y / 2 - 0.01f;*/


		//Définition limites caméra
		/*float COlim = Camera.main.transform.position.x - horzExtent ;
		float CElim = Camera.main.transform.position.x + horzExtent ;
		float CSlim = Camera.main.transform.position.y - vertExtent ;
		float CNlim = Camera.main.transform.position.y + vertExtent ;*/

		int Xgap10 = (int)(Camera.main.pixelHeight * rangeX);
		int Ygap10 = (int)(Camera.main.pixelWidth * rangeY);

		int In = Camera.main.pixelHeight - Xgap10;
		int Is = Xgap10;
		int Io = Ygap10;
		int Ie = Camera.main.pixelWidth - Ygap10-ihmSize;
		int On = Camera.main.pixelHeight;
		int Os = 0;
		int Oo = 0;
		int Oe = Camera.main.pixelWidth-ihmSize;

		Vector3 targetCamPos = Camera.main.WorldToScreenPoint (target.transform.position);

		if(targetCamPos.x >= Oo && targetCamPos.x < Io){// && COlim > Olim){ //Parie Ouest
			Camera.main.transform.Translate (Vector3.left * Time.deltaTime * speed* ((System.Math.Abs(targetCamPos.x - Io)) / Ygap10));   //Dernier chiffre facteur de proportionalité entre 0 et 1 de la speed
			//Debug.Log("Fact prop O");
			//Debug.Log(((System.Math.Abs(Input.mousePosition.x - Io)) / Ygap10));
		}
		if(targetCamPos.x > Ie && targetCamPos.x <= Oe){// && CElim < Elim){ //Partie Est
			Camera.main.transform.Translate (Vector3.right * Time.deltaTime * speed * ((System.Math.Abs(targetCamPos.x - Ie)) / Ygap10));   
			//Debug.Log("Fact prop E");
			//Debug.Log(((System.Math.Abs(Input.mousePosition.x - Ie)) / Ygap10));
		}
		if(targetCamPos.y >= Os && targetCamPos.y < Is){// && CSlim > Slim){ //Partie Sud 
			Camera.main.transform.Translate (Vector3.down * Time.deltaTime * speed * ((System.Math.Abs(targetCamPos.y - Is)) / Xgap10)); 
			//Debug.Log("Fact prop S");
			//Debug.Log(((System.Math.Abs(Input.mousePosition.y - Is)) / Xgap10));
		}
		if(targetCamPos.y > In && targetCamPos.y <= On){ //&& CNlim < Nlim){ //Partie Nord
			Camera.main.transform.Translate (Vector3.up * Time.deltaTime * speed * ((System.Math.Abs(targetCamPos.y - In)) / Xgap10)); 
			//Debug.Log("Fact prop N");
			//Debug.Log(((System.Math.Abs(Input.mousePosition.y - In)) / Xgap10));
		}
	}
}
