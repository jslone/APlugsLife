using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float rotSpeed = 4.0f;
	public RectTransform rtrans;

	// Use this for initialization
	void Start () {
		rtrans = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 eulerRot = rtrans.localEulerAngles;
		eulerRot.z += rotSpeed * Time.deltaTime;
		rtrans.localEulerAngles = eulerRot;
	}
}
