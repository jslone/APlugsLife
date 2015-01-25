using UnityEngine;
using System.Collections;

public class GUIFade : MonoBehaviour {
	public float Delay = 3.0f;
	public float FadeSpeed = 2.0f;

	private CanvasGroup canvasGroup;
	
	private float timeUntilFade = 0.0f;
	
	// Use this for initialization
	void Start () {
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
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
