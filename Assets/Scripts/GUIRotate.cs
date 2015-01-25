using UnityEngine;
using System.Collections;

public class GUIRotate : MonoBehaviour {
	public float RotSpeed = 360.0f;
	public float Delay = 0.5f;
	public float FadeSpeed = 2.0f;

	private RectTransform rectTrans;
	private CanvasGroup canvasGroup;

	private float timeUntilFade = 0.0f;

	// Use this for initialization
	void Start () {
		rectTrans = GetComponent<RectTransform> ();
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		rectTrans.Rotate(0,0,RotSpeed*Time.deltaTime);
		if(timeUntilFade < 0.0f) {
			canvasGroup.alpha = Mathf.Min(0.0f,canvasGroup.alpha - FadeSpeed * Time.deltaTime);
		}
	}
}
