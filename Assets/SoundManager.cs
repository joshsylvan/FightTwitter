using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource slap, intro, bgMusic, menu;
	GameplayManager gm;
	bool introPlayed = false;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameplayManager> ();
		this.bgMusic = GetComponents<AudioSource> ()[0];
		this.slap = GetComponents<AudioSource> ()[1];
		this.intro = GetComponents<AudioSource> ()[2];
		this.menu = GetComponents<AudioSource> ()[3];

	}
	
	// Update is called once per frame
	void Update () {
		if (!gm.IsGameOver()) {
			if (!this.intro.isPlaying && !introPlayed) {
				this.intro.Play ();
				introPlayed = true;
			}
			if (!this.intro.isPlaying && !this.bgMusic.isPlaying) {
				this.bgMusic.Play ();
			}
		} else {
			introPlayed = false;
			PlayMenuMusic ();
		}
	}

	public void PlaySlapSound(){
		if (!this.slap.isPlaying) {
			this.slap.Play ();
		}

	}

	public void PlayMenuMusic(){
		if (!this.menu.isPlaying) {
			StopAllMusic();
			this.menu.Play ();
		}
	}

	public void StopAllMusic(){
		this.slap.Stop ();
		this.intro.Stop ();
		this.bgMusic.Stop ();
		this.menu.Stop ();
	}
}
