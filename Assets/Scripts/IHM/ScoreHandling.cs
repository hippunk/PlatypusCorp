using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*[System.Serializable]
public class ScoreEntry{
	public string pseudo;
	public int score;

	public ScoreEntry(string pseudo,int score){
		this.pseudo = pseudo;
		this.score = score;
	}
}*/
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class ScoreHandling : MonoBehaviour {

	public Text[] score; 

	public GameObject submit;
	public Text pseudo;
	public HUDupdateScore hud;
	dreamloLeaderBoard dl;
	List<dreamloLeaderBoard.Score> scoreList = new List<dreamloLeaderBoard.Score>();
	bool updateRequest = true;
	bool fetchScores = false;
	int oldCount = 0;

	// Use this for initialization
	void Start () {
		dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
	}

	void Update(){
		if (updateRequest) {
			Debug.Log ("Update request");
			dl.LoadScores ();
			updateRequest = false;
			fetchScores = true;
		}
		if(fetchScores){
			Debug.Log ("fetchScores");
			scoreList =  dl.ToListHighToLow ();
			if (scoreList.Count != oldCount) {
				Debug.Log ("score fetched");
				populateBoard ();

				fetchScores = false;
				oldCount = scoreList.Count ();
			}
		}
	}

	void populateBoard(){
		int count = 0;
		foreach(dreamloLeaderBoard.Score currentScore in scoreList){
			score [count].text = (count+1)+" : " + currentScore.playerName + " " + currentScore.score.ToString();
			if (count >= 4) break;
			count++;
		}
	}

	public void addScore(){
		
		submit.SetActive (false);
		dl.AddScore(pseudo.text, hud.score);
		dreamloLeaderBoard.Score score = new dreamloLeaderBoard.Score ();
		score.playerName = pseudo.text;
		score.score = hud.score;
		scoreList.Add (score);

		//Reorder
		scoreList.Sort((x, y) => y.score.CompareTo(x.score));
		populateBoard ();
		Debug.Log ("submit");
	}
}
