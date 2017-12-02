using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource slap, intro, bgMusic;

	// Use this for initialization
	void Start () {
		this.bgMusic = GetComponents<AudioSource> ()[0];
		this.slap = GetComponents<AudioSource> ()[1];
		this.intro = GetComponents<AudioSource> ()[2];

		this.intro.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.intro.isPlaying && !this.bgMusic.isPlaying) {
			this.bgMusic.Play ();
		}
	}

	public void PlaySlapSound(){
		if (!this.slap.isPlaying) {
			this.slap.Play ();
		}

	}
}
