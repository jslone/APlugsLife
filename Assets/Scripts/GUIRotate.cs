using UnityEngine;
using System.Collections;

public class GUIRotate : MonoBehaviour {
	public Transform rot;
	public float RotSpeed = 360.0f;
	public float Delay = 3.0f;
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
		rectTrans.up = rot.up;
		rectTrans.Rotate(0,0,RotSpeed*Time.deltaTime);
		if(timeUntilFade < 0.0f) {
			canvasGroup.alpha = Mathf.Max(0.0f,canvasGroup.alpha - FadeSpeed * Time.deltaTime);
		} else {
			timeUntilFade -= Time.deltaTime;
		}
	}

	public void Alert() {
		timeUntilFade = Delay;
		canvasGroup.alpha = 1.0f;
	}
}
