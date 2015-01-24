using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D),typeof(Animator))]
public class CharacterMovement : MonoBehaviour {
	public GameObject world;
	public Feet feet;

	public float speed = 15.0f;
	public float jumpSpeed = 30.0f;
	public float rotSpeed = 1.0f;


	public bool squished = false;
	private int squishLayer;

	private Transform stuckTo = null;

	public bool canMove { get { return !feet.isStuck && !squished; } }
	public bool isGrounded { get { return feet.isGrounded; } }

	private Animator anim;

	// Use this for initialization
	void Start () {
		squishLayer = LayerMask.NameToLayer ("Squish");
		anim = GetComponent<Animator> ();
	}

	void Update() {
		anim.SetBool ("falling", !isGrounded);
		anim.SetBool ("squished", stuckTo != null);

	}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(horizontal));
		if(Mathf.Abs(horizontal) > 0.1f) {
			Vector3 scale = transform.localScale;
			scale.x = horizontal / Mathf.Abs (horizontal) * Mathf.Abs(scale.x);
			transform.localScale = scale;
        }
		if(canMove) {
			rigidbody2D.velocity = new Vector2(speed * horizontal,
			/*jumpSpeed * Input.GetAxis("Jump")*/rigidbody2D.velocity.y); // no more jump :'(
		}
		world.transform.RotateAround (transform.position, Vector3.forward, rotSpeed * Input.GetAxis ("Rotation"));
		if(stuckTo) {
			transform.rotation = Quaternion.identity;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = true;
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = true;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.layer == squishLayer) {
			squished = false;
		}
	}

	public void StickTo(Transform other) {
		stuckTo = other;
		transform.parent = other;
		transform.localPosition = Vector3.zero;
		rigidbody2D.isKinematic = true;
	}


}
