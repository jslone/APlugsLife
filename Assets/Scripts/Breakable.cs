using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
	int boulderLayer;

	public GameObject initial;
	public GameObject final;

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
			initial.SetActive(false);
			final.SetActive(true);
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.layer == boulderLayer) {
			collider2D.enabled = false;
			initial.SetActive(false);
			final.SetActive(true);
		}
	}
}
