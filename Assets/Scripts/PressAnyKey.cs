﻿using UnityEngine;
using System.Collections;

public class PressAnyKey : MonoBehaviour {
  public string LevelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    } else if (Input.anyKey) {
      Application.LoadLevel(LevelName);
    }
	
	}
}
