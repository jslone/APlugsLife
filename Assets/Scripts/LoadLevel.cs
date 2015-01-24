using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class LoadLevel : MonoBehaviour {
	public string LevelName;
	public bool RequireGrounded;

	void OnTriggerEnter2D(Collider2D other) {
		if(!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
		 	&& Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) < 0.1f)) {
			Application.LoadLevel (LevelName);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
			&& Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) < 0.1f)) {
			Application.LoadLevel (LevelName);
        }
    }
}
