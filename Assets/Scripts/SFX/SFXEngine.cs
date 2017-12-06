using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXEngine : MonoBehaviour {

	public AudioClip killClip;
	public AudioClip eatClip;
	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void playSFXKill(){
		audio.clip = killClip;
		audio.Play ();
	}

	public void playSFXEat(){
		audio.clip = eatClip;
		audio.Play ();
	}

}
