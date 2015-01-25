using UnityEngine;
using System.Collections;

public class GUIRotate : MonoBehaviour {
	public Transform rot;

	private RectTransform rectTrans;

	// Use this for initialization
	void Start () {
		rectTrans = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTrans.up = rot.up;
	}
}
