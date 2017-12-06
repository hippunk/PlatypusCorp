
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {
	
	//public List<GameObject> spawnPointList;
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
		//Object bundle;
		GameObject instance;

		working = true;
		while (working){
			yield return new WaitForSeconds (SpawnCycleTime);
			//Set dificulty computation here, load spawnpattern class rather than resources.load
			//Make a difficulty pool and a list collection ordered by difficulties
			//Then roll dices to choose and that's ok !

			//TODO HERE !
			//Populate difficulty pool
			//Debug.Log("Difficulty : "+difficulty);
			//if (poppedNum < 300) {
			if (_dynamics_.transform.childCount < 300) {
				foreach (GameObject go in spPat.getRandomPattern(difficulty)) {
					//Debug.Log ("\t pattern : "+go.name);
					instance = Instantiate (go) as GameObject;

					Vector3 randomPos = getRandomPosFromFar (20);
					//instance.transform.position = spawnPointList[Random.Range((int)0, (int)spawnPointList.Count)].transform.position;
					instance.transform.position = randomPos;
					GameObject warn = Instantiate (warning);
					warn.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1 - (((float)spPat.getDifficultyOfPattern (go)) / ((float)spPat.getMaxDifficulty ())), 0.0f);
					warn.GetComponent<AlignWithPlayer> ().dest = instance.transform.position;

					generate (instance);
					Destroy (instance);
				}
			}

			//


			//bundle = Resources.Load ("Prefabs/Pattern" + Random.Range((int)1, (int)12));

			difficulty += 1;
		}
	}

	public Vector3 getRandomPosFromFar(int distance){
		//Vector3 normVect = new Vector3(Mathf.Cos(Random.Range(0.0f, 2 * Mathf.PI)), Mathf.Sin(Random.Range(0.0f, 2 * Mathf.PI)) , 0);
		Vector3 normVect = (new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0.0f)).normalized;
		//Debug.Log ("Normalized vect: " + normVect);
		return (normVect * distance) + mainCamera.transform.position;
		//return ((new Vector3 (Mathf.Ceil(Random.Range (-1.0f, 1.0f)), Mathf.Ceil(Random.Range (-1.0f, 1.0f)), 0)) + mainCamera.transform.position) * distance;
	}

	public void generate(GameObject pack){
		GameObject generatedEnemy;
		//pack.transform.position = mainCamera.
		Transform child;
		for (int i = 0; i < pack.transform.childCount; ++i){
			child = pack.transform.GetChild (i);
			generatedEnemy = Instantiate (enemyPrefabs [Random.Range ((int)0, (int)enemyPrefabs.Count)]) as GameObject;
			//Vector3 pos = generatedEnemy.transform.localPosition;
			generatedEnemy.transform.SetParent (_dynamics_.transform);
			generatedEnemy.transform.position = child.position;
			generatedEnemy.transform.position = new Vector3(generatedEnemy.transform.position.x,
				generatedEnemy.transform.position.y, -5.0f);


		}
	}
}
