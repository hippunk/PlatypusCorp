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

public class ScoreHandling : MonoBehaviour {

	string path = "Scores";
	Dictionary<int,string> scores = new Dictionary<int,string>(); 

	// Use this for initialization
	void Start () {

		readFile ();

		scores.Add (450,"paul");
		//scores.Add ("karl",900);



		writeFile ();

	}


	void writeFile(){

		StreamWriter writer = new StreamWriter(path, false);

		var myList = scores.ToList ();
		myList.Sort ((pair2,pair1) => pair1.Key.CompareTo(pair2.Key));

		foreach (var entry in myList) {
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
}
