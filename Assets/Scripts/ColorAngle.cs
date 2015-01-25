using UnityEngine;
using System.Collections;

public class ColorAngle : MonoBehaviour {
	public static Color[] colors = new Color[] {
		new Color(248, 132, 8, 255)/255,
		new Color(38, 89, 245, 255)/255,
		new Color(12, 33, 43, 255)/255,
		new Color(24, 48, 113, 255)/255,
		new Color(73, 211, 111, 255)/255,
		new Color(137, 15, 2, 255)/255,
		new Color(23, 96, 92, 255)/255 
	};
	public static float index;
	public static bool blend = true;
	public float potency = 1.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float fdx = index * colors.Length;
		int idx = Mathf.FloorToInt (fdx);
		Color c;
		if(blend) {
			c = Color.Lerp(colors[idx],colors[(idx+1)%colors.Length],fdx-idx);
		} else {
			c = colors [idx];
		}
		renderer.material.color = Color.Lerp(Color.white,c,potency);
	}
}
