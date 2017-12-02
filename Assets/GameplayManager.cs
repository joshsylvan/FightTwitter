using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour {

	CameraFollow cameraFollow;
	float winCooldown = 3f;
	float ogWinCooldown = 3f;
	bool gameOver = false;
	public GameObject player1, player2;

	// Use this for initialization
	void Start () {
		this.cameraFollow = Camera.main.GetComponent<CameraFollow> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			winCooldown -= Time.deltaTime;
			if (winCooldown <= 0) {
				cameraFollow.BackToMenu ();
				winCooldown = ogWinCooldown;
				gameOver = false;
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.name == "Player1") {
			this.cameraFollow.PlayerDies (1);	
			gameOver = true;
		} else if (col.transform.name == "Player2") {
			this.cameraFollow.PlayerDies (2);	
			gameOver = true;
		}
	}

	public void StartGame(){
		this.cameraFollow.StartGame ();
		this.player1.transform.position = new Vector2 (-3.6f, 0);
		this.player2.transform.position = new Vector2 (3.6f, 0);
		gameOver = false;
		this.cameraFollow.ResetCamera ();
	}



}
