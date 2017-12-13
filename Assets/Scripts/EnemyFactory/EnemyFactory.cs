
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
	public int startDifficulty = 3;
	public int maxDifficulty = 25;
	public int spawnDistance = 15;

	public float horAcc = 0.0f;
	public float vertAcc = 0.0f;
	public float accSpeed = 0.5f;
	public float accDecreaseFactor = 1.0f;
	public float accClamp = 1.6f;
	public float accDelay = 1.2f;

	public int maxInstances = 200;
	float accumulator = 0;

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
		difficulty = startDifficulty;

		//Load datas from patterns informations
	
	}
	
	// Update is called once per frame
	void Update () {
		if (workRequest) {
			workRequest = false;
			StartCoroutine (makeEnemies ());
		}
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		//Manage accumulators for pop angle
		if (horizontal != 0)
			horAcc += Time.deltaTime * accSpeed * horizontal;
		else {
			horAcc += Time.deltaTime * accSpeed*accDecreaseFactor * (horAcc < 0 ? 1 : -1);
			if (Mathf.Abs(horAcc) < 0.05)
				horAcc = 0;
		}	
		if (vertical != 0)
			vertAcc += Time.deltaTime * accSpeed * vertical;
		else {
			vertAcc += Time.deltaTime * accSpeed*accDecreaseFactor * (vertAcc < 0 ? 1 : -1);
			if (Mathf.Abs(vertAcc) < 0.05)
				vertAcc = 0;
		}

		//Clamp accumulators
		horAcc = Mathf.Max(-1,Mathf.Min(1,horAcc));
		vertAcc = Mathf.Max(-1,Mathf.Min(1,vertAcc));
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
			if (_dynamics_.transform.childCount < maxInstances) {
				foreach (GameObject go in spPat.getRandomPattern(difficulty)) {
					//Debug.Log ("\t pattern : "+go.name);
					instance = Instantiate (go) as GameObject;

					Vector3 randomPos = getRandomPosFromFar (spawnDistance);
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

			difficulty = Mathf.Min(maxDifficulty,difficulty+1);
		}
	}
	void OnDrawGizmosSelected() {
		//Gizmo code for understand and watch algorithm
		Vector3 camPos = Camera.main.transform.position;
		camPos.z = 0;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(camPos, 1);

		//float horizontal = Input.GetAxis ("Horizontal");
		//float vertical = Input.GetAxis ("Vertical");



		Vector3 velocity = new Vector3();//(new Vector3 (horAcc,vertAcc,0)).normalized;

		//velocity.Normalize ();
		//Debug.Log ("velocity : "+velocity);
		velocity.x = horAcc* Mathf.Sqrt(1.0f - 0.5f*Mathf.Pow(vertAcc,2))*accClamp;
		velocity.y = vertAcc * Mathf.Sqrt (1.0f - 0.5f*Mathf.Pow (horAcc, 2))*accClamp;
		velocity.z = 0;
		//velocity= new Vector3(horAcc*2.0f,vertAcc*2.0f,0); 

		Vector3 dir = camPos + velocity;
		dir.z = 0;
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(dir, accDelay);
		//Gizmos.color = Color.red;
		//Gizmos.DrawWireSphere(mainCamera.transform.position, accClamp);
		for (int i = 0; i < 100; i++) {
			Vector3 normVect = (new Vector3 (Random.Range (-100.0f, 100.0f), Random.Range (-100.0f, 100.0f), 0.0f)).normalized * accDelay;

			Vector3 camToDir = dir - camPos;

			Vector3 objectif = camToDir + normVect;

			Gizmos.color = Color.red;
			Gizmos.DrawLine (camPos, camPos + objectif.normalized);
		}
	}
	public Vector3 getRandomPosFromFar(int distance){
		//Vector3 normVect = new Vector3(Mathf.Cos(Random.Range(0.0f, 2 * Mathf.PI)), Mathf.Sin(Random.Range(0.0f, 2 * Mathf.PI)) , 0);

		/*float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");


		Vector2 velocity = new Vector2 (horizontal,vertical);
		//Debug.Log ("velocity : "+velocity);
		velocity= velocity.normalized; 

		//Debug.Log ("velocity norm : "+velocity);
		Vector3 normVect = (new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0.0f)).normalized*0.5f;
		//Debug.Log ("norm rand : "+normVect);

		Vector3 dir = (new Vector3(normVect.x+velocity.x,normVect.y+velocity.y,0)).normalized;
		//Debug.Log ("dir : "+velocity);

		Debug.Log (normVect);
		Debug.Log (dir);*/
		//camera pos with guarantee z = 0 for normalisations
		Vector3 camPos = Camera.main.transform.position;
		camPos.z = 0;

		//Compute vector related to movement accumulators
		Vector3 velocity = new Vector3();
		velocity.x = horAcc* Mathf.Sqrt(1.0f - 0.5f*Mathf.Pow(vertAcc,2))*accClamp;
		velocity.y = vertAcc * Mathf.Sqrt (1.0f - 0.5f*Mathf.Pow (horAcc, 2))*accClamp;
		velocity.z = 0;
		//velocity= new Vector3(horAcc*2.0f,vertAcc*2.0f,0); 

		Vector3 dir = camPos + velocity;
		dir.z = 0;
		Vector3 normVect = (new Vector3 (Random.Range (-100.0f, 100.0f), Random.Range (-100.0f, 100.0f), 0.0f)).normalized * accDelay;

		Vector3 camToDir = dir - camPos;

		Vector3 objectif = camToDir + normVect;

		return (objectif.normalized * distance) + camPos;
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
