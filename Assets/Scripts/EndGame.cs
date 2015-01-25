using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class EndGame : MonoBehaviour {
	public bool RequireGrounded = true;
	public GUIShrink gui;
	
	void OnTriggerEnter2D(Collider2D other) {
		if ((!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
		 && Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) > 0.8f))) {
			other.GetComponent<CharacterMovement>().inputDisabled = true;
			gui.Alert();
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if ((!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
		 && Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) > 0.8f))) {
			other.GetComponent<CharacterMovement>().inputDisabled = true;	
			gui.Alert();
		}
	}
}
