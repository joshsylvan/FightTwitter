using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

	CameraFollow cameraFollow;

	// Use this for initialization
	void Start () {
		this.cameraFollow = Camera.main.GetComponent<CameraFollow> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Player") {
		
		}
	}

	public void StartGame(){
		this.cameraFollow.StartGame ();
	}

}
