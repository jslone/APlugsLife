using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Pit : MonoBehaviour {
	public float Length;

	private GUIRotate gui;

	// Use this for initialization
	void Start () {
		gui = FindObjectOfType<GUIRotate> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.transform.position += Length * transform.up;
		if (gui && other.CompareTag ("Player")) {
			gui.Alert();
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		other.transform.position += Length * transform.up;
		if (gui && other.CompareTag ("Player")) {
			gui.Alert();
		}
	}
}
