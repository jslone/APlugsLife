using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Pit : MonoBehaviour {
	public float Length;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.transform.position += Length * transform.up;
	}

	void OnTriggerStay2D(Collider2D other) {
		other.transform.position += Length * transform.up;
	}
}
