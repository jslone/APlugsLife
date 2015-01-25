using UnityEngine;
using System.Collections;

public class Shrink : MonoBehaviour {

	float speedFactor = 0.9f;
	bool shrinking = false;
	public Animator anim;
	public AudioSource spark;

	public float Delay = 1.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localScale.x < 0.5f) {
			anim.SetTrigger("spark");
			spark.Play();
			return;
		}
		if(shrinking) {
			if(Delay < 0) {
				transform.localScale *= speedFactor;
			} else {
				Delay -= Time.deltaTime;
			}
		}
	}

	public void Alert() {
		shrinking = true;
	}
}
