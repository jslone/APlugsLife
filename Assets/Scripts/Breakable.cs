using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
	int boulderLayer;

	// Use this for initialization
	void Start () {
		boulderLayer = LayerMask.NameToLayer ("Boulder");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.layer == boulderLayer) {
			collider2D.enabled = false;
			renderer.enabled = false;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.layer == boulderLayer) {
			collider2D.enabled = false;
			renderer.enabled = false;
		}
	}
}
