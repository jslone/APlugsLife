﻿using UnityEngine;
using System.Collections;

public class Plug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.GetComponent<CharacterMovement> ().StickTo (transform);
	}
}
