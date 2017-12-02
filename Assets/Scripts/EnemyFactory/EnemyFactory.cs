
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {
	public List<Component> movementScriptList;
	public GameObject target;

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
			if (target)
				child.GetComponent<MoveToPlayer> ().target = target;
			child.GetComponent<MoveToPlayer>().angularSpeed += Random.Range(-0.5f, 0.5f);
		}
	}
}
