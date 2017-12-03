using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Pattern{
	public int difficulty;
	public List<GameObject> patterns = new List<GameObject>();


}

[System.Serializable]
public class SpawnPatterns : MonoBehaviour {

	//public int patternsNumber;
	public List<Pattern> patterns = new List<Pattern>();

	//select random difficulty with max difficulty
	Pattern getRandomMaxDifficultyPattern(int max){
		List<Pattern> tmpList = new List<Pattern> ();

		foreach(Pattern pattern in patterns){
			if (pattern.difficulty <= max)
				tmpList.Add (pattern);	
		}

		return tmpList[Random.Range(0,tmpList.Count)];
	}

	public List<GameObject> getRandomPattern(int difficulty){
		List<GameObject> tmpList = new List<GameObject> ();
		int tmpDifficulty = difficulty;
		while (tmpDifficulty > 0) {
			Pattern pattern = getRandomMaxDifficultyPattern (tmpDifficulty);
			tmpList.Add (pattern.patterns[Random.Range(0,pattern.patterns.Count)]);
			tmpDifficulty -= pattern.difficulty;
		}

		return tmpList;
	}
}
