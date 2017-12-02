using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;

	float horizontalAxis;
	public float speed = 3f;
	float jumpPower = 400f;
	public int controller = 1;
	SoundManager soundManager;

	XboxCtrlrInput.XboxController controlerID;

	// Use this for initialization
	void Start () {
		this.soundManager = GameObject.Find ("GameManager").GetComponent<SoundManager> ();
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();

		switch (controller) {
		case 1:
			controlerID = XboxCtrlrInput.XboxController.First;
			break;
		case 2:
			controlerID = XboxCtrlrInput.XboxController.Second;
			break;
		default:
			controlerID = XboxCtrlrInput.XboxController.First;
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (XboxCtrlrInput.XCI.GetButtonDown (XboxCtrlrInput.XboxButton.X, controlerID)) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Slap")) {
				anim.SetTrigger ("Slap");
			}
		}

		if (XboxCtrlrInput.XCI.GetDPad (XboxCtrlrInput.XboxDPad.Left, controlerID)) {
			this.transform.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
			horizontalAxis = -1;
		} else if (XboxCtrlrInput.XCI.GetDPad (XboxCtrlrInput.XboxDPad.Right, controlerID)) {
			this.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			horizontalAxis = 1;
		} else {
			horizontalAxis = 0;
		}

		if (XboxCtrlrInput.XCI.GetButtonDown (XboxCtrlrInput.XboxButton.A, controlerID) && this.rb.velocity.y == 0) {
			rb.AddForce (new Vector2(0, jumpPower));
		}
	}

	void FixedUpdate(){
		this.rb.velocity = new Vector2 (horizontalAxis * speed * Time.fixedDeltaTime, this.rb.velocity.y);
	}

	public void IveBeenSlapped(){
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "HandCollider") {
			Debug.Log (this.name + " hit " + col.transform.parent.name);
			if (this.gameObject.name != col.transform.parent.name) {
				soundManager.PlaySlapSound ();
				if (this.rb.velocity.y == 0) {
					this.rb.AddForce (new Vector2 (-1500, 200));
				} else {
					this.rb.AddForce (new Vector2 (1500, 0));
				}
			}
		}
	}
}
