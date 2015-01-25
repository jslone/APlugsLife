using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer),typeof(Collider2D))]
public class SpriteToggle : MonoBehaviour {
	SpriteRenderer rendr;
	public Sprite on;
	public Sprite off;

	// Use this for initialization
	void Start () {
		rendr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		rendr.sprite = on;
	}

	void OnTriggerExit2D(Collider2D other) {
		rendr.sprite = off;
	}
}
