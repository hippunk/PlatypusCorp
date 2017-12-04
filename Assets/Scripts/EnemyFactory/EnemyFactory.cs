
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
	public GameObject warning;

	private SpawnPatterns spPat;
	private List<Object> enemyPrefabs;
	private int difficulty;
	//private List<DifficultyPool> difficultiesPool = new List<DifficultyPool> ();
	//private List<int>[] patternMapper = new Dictionary<int,int> ();

	// Use this for initialization
	void Start () {
		working = false;
		spPat = GetComponent<SpawnPatterns> ();
		SpawnCycleTime = 5.0f;
		enemyPrefabs = new List<Object> ();
		for (int i = 1; i <= 5; ++i) {
			enemyPrefabs.Add (Resources.Load("Prefabs/EnemyTemplate/Enemy" + i));
		}
		difficulty = 1;

		//Load datas from patterns informations
	
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
			//Set dificulty computation here, load spawnpattern class rather than resources.load
			//Make a difficulty pool and a list collection ordered by difficulties
			//Then roll dices to choose and that's ok !

			//TODO HERE !
			//Populate difficulty pool
			Debug.Log("Difficulty : "+difficulty);
			foreach (GameObject go in spPat.getRandomPattern(difficulty)) {
				Debug.Log ("\t pattern : "+go.name);
				instance = Instantiate (go) as GameObject;
				instance.transform.position = spawnPointList[Random.Range((int)0, (int)spawnPointList.Count)].transform.position;
				GameObject warn = Instantiate (warning);
				warn.GetComponent<AlignWithPlayer> ().dest = instance.transform.position;
				generate (instance);
				Destroy (instance);
			}

			//


			//bundle = Resources.Load ("Prefabs/Pattern" + Random.Range((int)1, (int)12));






			difficulty += 1;
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
