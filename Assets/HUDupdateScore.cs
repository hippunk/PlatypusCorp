using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDupdateScore : MonoBehaviour {
	public Text field;
	public Text field2;
	public int score;
	private float timer;
	public bool end;
	// Use this for initialization
	void Start () {
		score = 0;
		end = false;
		timer = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float timeSpent = Time.time - timer;
		if (!end && timeSpent * 100 >= 1.0f ) {
			addToScore ((int)(timeSpent * 100));
			timer = Time.time;
		}
	}

	public void stopScore(){
		end = true;
	}

	public void addToScore(int value){
		score += value;

		field.text = "---SCORE---\n" + score;
		field2.text = "---SCORE---\n" + score;
	}
}
