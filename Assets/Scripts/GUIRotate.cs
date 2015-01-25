using UnityEngine;
using System.Collections;

public class GUIRotate : MonoBehaviour {
	public Transform rot;

	private RectTransform rectTrans;
	private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
		rectTrans = GetComponent<RectTransform> ();
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTrans.up = rot.up;
	}
}
