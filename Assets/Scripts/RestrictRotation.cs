using UnityEngine;
using System.Collections;

public class RestrictRotation : MonoBehaviour {
    public CharacterMovement character;

	// Use this for initialization
	void Start () {
        character.canRotate = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        character.canRotate = true;
    }
}
