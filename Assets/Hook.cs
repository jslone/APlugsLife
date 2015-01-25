using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {
	public Transform match;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.up = -match.up;
	}
}
