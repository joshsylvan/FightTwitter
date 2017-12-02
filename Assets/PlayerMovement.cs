using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;

	float horizontalAxis;
	float speed = 1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = this.transform.parent.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (XboxCtrlrInput.XCI.GetButtonDown (XboxCtrlrInput.XboxButton.X)) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Slap")) {
				anim.SetTrigger ("Slap");
			}
		}

		if (XboxCtrlrInput.XCI.GetDPad (XboxCtrlrInput.XboxDPad.Left)) {
			this.transform.localScale = new Vector3 (-1f, 1f, 1);
			horizontalAxis = -1;
		} else if (XboxCtrlrInput.XCI.GetDPad (XboxCtrlrInput.XboxDPad.Right)) {
			this.transform.localScale = new Vector3 (1f, 1f, 1);
			horizontalAxis = 1;
		} else {
			horizontalAxis = 0;
		}
	}

	void FixedUpdate(){
		this.rb.velocity = new Vector2 (horizontalAxis * speed * Time.fixedTime, this.rb.velocity.y);
	}
}
