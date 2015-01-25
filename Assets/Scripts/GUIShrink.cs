using UnityEngine;
using System.Collections;

[RequireComponent (typeof(RectTransform))]
public class GUIShrink : MonoBehaviour {
	RectTransform rtrans;

	float speedFactor = 0.9f;
	bool shrinking = false;

	public float Delay = 1.5f;

	// Use this for initialization
	void Start () {
		rtrans = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(shrinking && rtrans.localScale.x > 0.5f) {
			if(Delay < 0) {
				rtrans.localScale *= speedFactor;
			} else {
				Delay -= Time.deltaTime;
			}
		}
	}

	public void Alert() {
		shrinking = true;
	}
}
