using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target1, target2;

	float cameraSpeed = 1.5f;
	float cameraOffset = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetPosition = (target1.transform.position + target2.transform.position)/2;

		Vector3 newPosition = Vector3.Lerp (this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);

		this.transform.position = new Vector3 (newPosition.x, newPosition.y, -10);

	}
}
