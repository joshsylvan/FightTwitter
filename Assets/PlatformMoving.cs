using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

	GameObject[] platforms;

	int platformID = 0;
	float randomSeconds = 5;

	bool platformMoving = false;

	Vector2 target, oldPosition;

	// Use this for initialization
	void Start () {
		platforms = new GameObject[this.transform.childCount];
		for (int i = 0; i < this.transform.childCount; i++) {
			platforms [i] = transform.GetChild (i).gameObject;
		}
//		oldPosition = platforms [0].transform.position;
//		target = new Vector2 (oldPosition.x, oldPosition.y-6f);
	}
	
	// Update is called once per frame
	void Update () {
		randomSeconds -= Time.deltaTime;
		if (randomSeconds <= 0 && !platformMoving) {
			randomSeconds = Random.Range (5, 6);
			platformID = Random.Range (0, 3);
			oldPosition = platforms [platformID].transform.position;
			target = new Vector2 (oldPosition.x, oldPosition.y-7);
			platformMoving = true;
		}

		if (platformMoving) {	
			if (randomSeconds > 0) {
				this.MoveDown (platformID);
			} else {
				this.MoveUp (platformID);
				if (Vector2.Distance (this.platforms [platformID].transform.position, oldPosition) <= 0.1f) {
					platformMoving = false;
				}
			}

		}

	}

	void MoveUp(int platformID){
		Vector2 targetPosition = Vector2.Lerp(this.platforms[platformID].transform.position, oldPosition , .5f*Time.deltaTime);
		this.platforms [platformID].transform.position = new Vector3 (targetPosition.x, targetPosition.y, 0);
	}

	void MoveDown(int platformID){
		Vector2 targetPosition = Vector2.Lerp(this.platforms[platformID].transform.position, target , .5f*Time.deltaTime);
		this.platforms [platformID].transform.position = new Vector3 (targetPosition.x, targetPosition.y, 0);
	}

}
