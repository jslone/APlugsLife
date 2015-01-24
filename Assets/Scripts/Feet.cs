using UnityEngine;
using System.Collections;

public class Feet : MonoBehaviour {
	private bool touchedLastFrame = false;
	private bool stuckLastFrame = false;
	public bool isGrounded = false;
	public bool isStuck = false;

	private int stuckLayer;
	void Start() {
		stuckLayer = LayerMask.NameToLayer ("NoWalk");
	}

	void FixedUpdate() {
		if(!touchedLastFrame) {
			isGrounded = false;
		} else {
			touchedLastFrame = false;
		}

		if(!stuckLastFrame) {
			isStuck = false;
		} else {
			stuckLastFrame = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		touchedLastFrame = true;
		isGrounded = true;
		if(other.gameObject.layer == stuckLayer) {
			stuckLastFrame = true;
			isStuck = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		touchedLastFrame = true;
		isGrounded = true;
		if(other.gameObject.layer == stuckLayer) {
			stuckLastFrame = true;
			isStuck = true;
        }
    }
}
