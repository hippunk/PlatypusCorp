﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {
	public List<GameObject> spawnPointList;
	public GameObject _dynamics_;
	private bool workRequest;
	private bool working;
	public Camera mainCamera;
	public float SpawnCycleTime;
	private List<Object> enemyPrefabs;
	private int difficulty;

	// Use this for initialization
	void Start () {
		working = false;
		SpawnCycleTime = 5.0f;
		enemyPrefabs = new List<Object> ();
		for (int i = 1; i <= 5; ++i) {
			enemyPrefabs.Add (Resources.Load("Prefabs/EnemyTemplate/Enemy" + i));
		}
		difficulty = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (workRequest) {
			workRequest = false;
			StartCoroutine (makeEnemies ());
		}
	}

	public void startWorking(){
		workRequest = true;
	}

	IEnumerator makeEnemies(){
		Object bundle;
		GameObject instance;

		working = true;
		while (working){
			bundle = Resources.Load ("Prefabs/Pattern" + Random.Range((int)1, (int)12));
			instance = Instantiate (bundle) as GameObject;
			instance.transform.position = spawnPointList[Random.Range((int)0, (int)spawnPointList.Count)].transform.position;

			generate (instance);
			Destroy (instance);
			yield return new WaitForSeconds (SpawnCycleTime);
		}
	}

	public void generate(GameObject pack){
		GameObject generatedEnemy;
		//pack.transform.position = mainCamera.
		foreach (Transform child in pack.transform) {
			//randomIndex = Random.Range ((int)0, pack.transform.childCount);
			//child.gameObject.AddComponent (movementScriptList[randomIndex]);

			generatedEnemy = Instantiate (enemyPrefabs [Random.Range ((int)0, (int)enemyPrefabs.Count)]) as GameObject;
			//Vector3 pos = generatedEnemy.transform.localPosition;
			generatedEnemy.transform.SetParent (_dynamics_.transform);
			generatedEnemy.transform.localPosition = child.position;
			generatedEnemy.GetComponent<MoveToPlayer>().translationSpeed += Random.Range(-0.5f, 0.5f);

			/*if (Random.Range (0.0f, 1.0f) < 0.3f) {
				child.GetComponent<MoveToPlayer>().angularSpeed = 0;
				child.GetComponent<MoveToPlayer>().translationSpeed += 2;
			}
			else
				child.GetComponent<MoveToPlayer>().angularSpeed += Random.Range(-0.5f, 0.5f);
			child.GetComponent<MoveToPlayer>().translationSpeed += Random.Range(-0.5f, 0.5f);*/

		}
	}
}
