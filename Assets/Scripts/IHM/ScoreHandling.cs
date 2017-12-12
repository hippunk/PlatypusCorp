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

	public GameObject scoreRow; 
	public RectTransform content; 
	public GameObject scorePanel;

	public GameObject submit;
	public Text pseudo;
	public HUDupdateScore hud;
	public int nbScores = 10;
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
			submit.SetActive (false);
		}
		if(fetchScores){
			Debug.Log ("fetchScores");
			scoreList =  dl.ToListHighToLow ();
			if (scoreList.Count != oldCount) {
				Debug.Log ("score fetched");
				populateBoard ();

				fetchScores = false;
				if (isInTop ()) {
					submit.SetActive (true);
				}
				oldCount = scoreList.Count ();
			}
		}
	}

	void populateBoard(){
		int count = 0;
		foreach(dreamloLeaderBoard.Score currentScore in scoreList){
			content.sizeDelta = new Vector2(content.sizeDelta.x,30 * nbScores);
			//score [count].transform.GetChild(1).GetComponent<Text>().text = currentScore.playerName ;
			//score [count].transform.GetChild(2).GetComponent<Text>().text = currentScore.score.ToString();
			GameObject row = Instantiate(scoreRow,scorePanel.transform);
			RectTransform rowRect = row.GetComponent<RectTransform> ();
			rowRect.sizeDelta = new Vector2 (200, 30);
			row.transform.GetChild(0).GetComponent<Text>().text = (count+1).ToString() ;
			row.transform.GetChild(2).GetComponent<Text>().text = currentScore.playerName ;
			row.transform.GetChild(3).GetComponent<Text>().text = currentScore.score.ToString();
			if (count >= nbScores-1) break;
			count++;
		}
	}

	public bool isInTop(){
		int count = 0;
		foreach(dreamloLeaderBoard.Score currentScore in scoreList){
			if (currentScore.score < hud.score)
				return true;

			if (count >= nbScores-1) break;
			count++;
		}

		return false;
	}
}
