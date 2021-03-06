﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D),typeof(Animator))]
public class CharacterMovement : MonoBehaviour {
	public Feet feet;

	public float speed = 15.0f;
	public float jumpSpeed = 30.0f;

	public Vector3[] Dirs;
	public float rotationSpeed = 1.0f;
	private float rotation = 0.0f;


	public bool squished = false;
	private int squishLayer;

	private Transform stuckTo = null;

	public bool inputDisabled = false;
	public bool canMove { get { return !feet.isStuck && !squished && !inputDisabled; } }
	public bool isGrounded { get { return feet.isGrounded; } }
	public bool canRotate = true;

	private Animator anim;

	// Use this for initialization
	void Start () {
		squishLayer = LayerMask.NameToLayer ("Squish");
		anim = GetComponent<Animator> ();
	}

	void Update() {
		anim.SetBool ("falling", !isGrounded);
		anim.SetBool ("squished", squished);
		anim.SetBool ("hanging", stuckTo);
		anim.SetFloat ("speed", Mathf.Abs(Vector2.Dot(rigidbody2D.velocity,transform.right)));

		if(!inputDisabled) {
			float rotDelta = Input.GetAxis ("Rotation");
			if(canRotate && Mathf.Abs(rotDelta) > 0.1f) {
				rotation += rotationSpeed * Time.deltaTime * rotDelta;
			} else {
				rotation = Mathf.Lerp(rotation,Mathf.Round(rotation),rotationSpeed*Time.deltaTime);
			}

			if(Input.GetAxis("Vertical") < 0.0f) {
				stuckTo = null;
				transform.parent = null;
				rigidbody2D.isKinematic = false;
			}
		}


		int idx1 = ((Mathf.FloorToInt (rotation) % Dirs.Length) + Dirs.Length) % Dirs.Length;
		int idx2 = (((idx1 + 1) % Dirs.Length) + Dirs.Length) % Dirs.Length;
		Vector3 dir = Vector3.Lerp (Dirs [idx1], Dirs [idx2], rotation - Mathf.Floor(rotation));

		if(!stuckTo) {
			transform.up = dir;
		} else {
			Physics2D.gravity = -dir;
		}

		ColorAngle.index = (rotation / Dirs.Length) - Mathf.Floor(rotation / Dirs.Length);

		if(Vector3.Dot(transform.forward,Vector3.forward) < 0.0f) {
			Vector3 rot = transform.localEulerAngles;
			rot.y = 0;
			transform.localEulerAngles = rot;
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Title");
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
		if(!inputDisabled) {
			float horizontal = Input.GetAxis("Horizontal");

			if(Mathf.Abs(horizontal) > 0.1f) {
				Vector3 scale = transform.localScale;
				scale.x = horizontal / Mathf.Abs (horizontal) * Mathf.Abs(scale.x);
				transform.localScale = scale;
	        }
			if(canMove) {
				Vector2 upV = Vector2.Dot(transform.up,rigidbody2D.velocity) * transform.up;
				rigidbody2D.velocity = horizontal * speed * (Vector2)transform.right + upV;
			}
			/*if(stuckTo) {
				transform.position = stuckTo.position;
			}*/
			if(!stuckTo) {
				Physics2D.gravity = -9.8f * transform.up;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = true;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = true;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = false;
		}
	}

	public void StickTo(Transform other) {
		stuckTo = other;
		transform.position = stuckTo.position;
		transform.parent = stuckTo;
		rigidbody2D.isKinematic = true;
	}


}
