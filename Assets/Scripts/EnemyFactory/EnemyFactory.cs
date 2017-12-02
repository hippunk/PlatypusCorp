
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {
	public List<Component> movementScriptList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void generate(GameObject pack){
		int randomIndex;

		foreach (Transform child in pack.transform) {
			//randomIndex = Random.Range ((int)0, pack.transform.childCount);
			//child.gameObject.AddComponent (movementScriptList[randomIndex]);
			if (Random.Range (0.0f, 1.0f) < 0.3f) {
				child.GetComponent<MoveToPlayer>().angularSpeed = 0;
				child.GetComponent<MoveToPlayer>().translationSpeed += 2;
			}
			else
				child.GetComponent<MoveToPlayer>().angularSpeed += Random.Range(-0.5f, 0.5f);
			child.GetComponent<MoveToPlayer>().translationSpeed += Random.Range(-0.5f, 0.5f);

		}
	}
}
