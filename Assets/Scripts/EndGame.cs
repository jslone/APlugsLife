using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class EndGame : MonoBehaviour {
	public bool RequireGrounded = true;
	public Shrink shr;
	
	void OnTriggerEnter2D(Collider2D other) {
		if ((!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
		 && Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) > 0.8f))) {
			other.GetComponent<CharacterMovement>().inputDisabled = true;
			shr.Alert();
			Invoke("Credits",5);
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if ((!RequireGrounded || 
		   (other.gameObject.GetComponent<CharacterMovement>().isGrounded 
		 && Mathf.Abs(Vector3.Dot(other.transform.up,transform.up)) > 0.8f))) {
			other.GetComponent<CharacterMovement>().inputDisabled = true;	
			shr.Alert();
		}
	}

	void Credits() {
		Application.LoadLevel ("Credits");
	}
}
