using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown_Controller : MonoBehaviour {

	public float speed = 0.1f;
	private KeyCode buttonUp;
	private KeyCode buttonLeft;
	private KeyCode buttonDown;
	private KeyCode buttonRight;
	private SpriteRenderer mySpriteRenderer;
	private Animator myAnimator;
	
	void Start() {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		myAnimator = GetComponent<Animator>();
		buttonUp = KeyCode.W;
		buttonLeft = KeyCode.A;
		buttonDown = KeyCode.S;
		buttonRight = KeyCode.D;
	}

	// Update is called once per frame
	void Update () {
		myAnimator.SetBool("Walking", false);
		if (Input.GetKey(buttonUp)){
			transform.Translate (Vector2.up * speed);
			myAnimator.SetBool("Walking", true);
		}
		if (Input.GetKey(buttonLeft)){
			transform.Translate (Vector2.left * speed);
			mySpriteRenderer.flipX = false;
			myAnimator.SetBool("Walking", true);
		}
		if (Input.GetKey(buttonDown)){
			transform.Translate (Vector2.down * speed);
			myAnimator.SetBool("Walking", true);
		}
		if (Input.GetKey(buttonRight)){
			transform.Translate (Vector2.right * speed);
			mySpriteRenderer.flipX = true;
			myAnimator.SetBool("Walking", true);
		}
	}
}
