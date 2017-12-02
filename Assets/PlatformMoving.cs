using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

	GameObject[] platforms;

	int platformID = 0;
	float randomSeconds = 10;

	bool platformMoving = false;

	Vector2 target, oldPosition;

	// Use this for initialization
	void Start () {
		platforms = new GameObject[this.transform.childCount];
		for (int i = 0; i < this.transform.childCount; i++) {
			platforms [i] = transform.GetChild (i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		randomSeconds -= Time.deltaTime;
		if (randomSeconds <= 0 && !platformMoving) {
			randomSeconds = Random.Range (0, 15);
			platformID = Random.Range (0, 3);
			oldPosition = platforms [platformID].transform.position;
			target = new Vector2 (oldPosition.x, oldPosition.y-2);
			platformMoving = true;
		}

		if (platformMoving) {

			Vector2 targetPosition = target;

			Vector2 newPosition = Vector2.Lerp (platforms[platformID].transform.position, targetPosition, 1f * Time.deltaTime);

			this.transform.position = new Vector3 (newPosition.x, newPosition.y, -10);
		}

	}
}
