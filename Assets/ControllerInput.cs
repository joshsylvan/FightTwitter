using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (XboxCtrlrInput.XCI.IsPluggedIn (XboxCtrlrInput.XboxController.First)) {
			Debug.Log ("SOMTHING");
		}

		if (XboxCtrlrInput.XCI.GetButton(XboxCtrlrInput.XboxButton.A)) {
			Debug.Log ("YEH");
		}
		
	}
}
