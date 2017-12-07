using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXEngine : MonoBehaviour {

	public AudioClip killClip;
	public AudioClip eatClip;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	public void playSFXKill(){
		audioSource.clip = killClip;
		audioSource.Play ();
	}

	public void playSFXEat(){
		audioSource.clip = eatClip;
		audioSource.Play ();
	}

}
