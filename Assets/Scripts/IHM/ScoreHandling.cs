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

	string path = "Assets/Scores";

	public Text[] score; 

	public GameObject submit;
	public Text pseudo;
	public HUDupdateScore hud;

	Dictionary<int,string> scores = new Dictionary<int,string>(); 

	// Use this for initialization
	void Start () {
		Debug.Log ("start");
		readFile ();
		populateBoard ();

		var myList = scores.ToList ();
		myList.Sort ((pair2,pair1) => pair1.Key.CompareTo(pair2.Key));
		//Vérifier si score dans les 5 premiers

		if(!inTopFive())
			submit.SetActive (false);

		//scores.Add (450,"paul");
		//scores.Add ("karl",900);


		//writeFile ();
	}


	bool inTopFive(){
		var myList = scores.ToList ();
		myList.Sort ((pair2,pair1) => pair1.Key.CompareTo(pair2.Key));

		if (myList.Count () < 5)
			return true;

		for (int i = 0; i < 5 && i < myList.Count (); i++) {
			var elem = myList.ElementAt (i);
			if (elem.Key < hud.score)
				return true;
		}

		return false;
	}

	void populateBoard(){

		var myList = scores.ToList ();
		myList.Sort ((pair2,pair1) => pair1.Key.CompareTo(pair2.Key));

		for (int i = 0; i < 5; i++) {
			if (i < myList.Count () && i < score.Length) {
				var elem = myList.ElementAt (i);
				score [i].text = (i+1)+" : " + elem.Value + " " + elem.Key;

			} else {
				score [i].text = (i+1)+" : ";
			}
		}
	}

	void writeFile(){

		StreamWriter writer = new StreamWriter(path, false);

		var myList = scores.ToList ();
		myList.Sort ((pair2,pair1) => pair1.Key.CompareTo(pair2.Key));


		for (int i = 0; i < 5; i++) {
			var entry = myList.ElementAt (i);
			writer.WriteLine(entry.Value+" "+entry.Key);
		}

		writer.Close();
	}

	void readFile(){

		StreamReader reader = new StreamReader(path); 
		for(string line = reader.ReadLine ();line != null;line = reader.ReadLine ()) {
			string[] toks = line.Split(' ');
			scores.Add (int.Parse(toks[1]),toks[0]);
		}

		reader.Close();
	}

	public void addScore(){
		Debug.Log ("submit");
		submit.SetActive (false);

		scores.Add (hud.score,pseudo.text);
		populateBoard ();
		writeFile ();

	}
}
