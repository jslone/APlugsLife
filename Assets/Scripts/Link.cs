using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Joint2D))]
public class Link : MonoBehaviour {
	private Vector3 scale;
	private Transform next;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
		next = GetComponent<Joint2D>().connectedBody.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = next.position - transform.position;
		scale.y = dir.magnitude / 1.25f;
		transform.localScale = scale;
		transform.up = dir;
	}
}
