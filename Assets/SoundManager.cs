using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource slap;

	// Use this for initialization
	void Start () {
		this.slap = GetComponents<AudioSource> ()[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySlapSound(){
		if (!this.slap.isPlaying) {
			this.slap.Play ();
		}

	}
}
