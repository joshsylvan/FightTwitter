using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target1, target2;
	bool gameStart = false;

	float cameraSpeed = 1.5f, cameraSpeedSlow = .5f, currentSpeed;
	float cameraCooldown = 6f, ogCameraCooldown = 6f;
	float cameraOffset = 3f;

	bool playerDead = false;
	int playerID = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameStart) {

			if (playerDead) {
				
				Vector3 targetPosition;
				if (playerID == 1) {
					targetPosition = (target2.transform.position);
				} else if (playerID == 2) {
					targetPosition = (target1.transform.position);
				} else {
					targetPosition = Vector2.zero;
				}

				Vector3 newPosition = Vector3.Lerp (this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

				this.transform.position = new Vector3 (newPosition.x, newPosition.y, -10);
			} else {
				cameraCooldown -= Time.deltaTime;
				if (cameraCooldown < 0) {
					currentSpeed = this.cameraSpeed;
				} else {
					currentSpeed = this.cameraSpeedSlow;
				}
				Vector3 targetPosition = (target1.transform.position + target2.transform.position) / 2;

				Vector3 newPosition = Vector3.Lerp (this.transform.position, targetPosition, currentSpeed * Time.deltaTime);

				this.transform.position = new Vector3 (newPosition.x, newPosition.y, -10);
			}

		} else {
			Vector3 targetPosition = new Vector2 (0, 69);

			Vector3 newPosition = Vector3.Lerp (this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

			this.transform.position = new Vector3 (newPosition.x, newPosition.y, -10);
		}

	}

	public void PlayerDies(int ID){
		this.playerDead = true;
		this.playerID = ID;
		cameraCooldown = ogCameraCooldown;
	}

	public void StartGame(){
		gameStart = true;
	}

	public void BackToMenu (){
		gameStart = false;
	}

	public void ResetCamera(){
		this.playerDead = false;
		this.playerID = 0;
	}
}
