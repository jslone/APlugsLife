using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Renderer))]
public class Tile : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		renderer.material.mainTextureScale = (new Vector2 (transform.localScale.x, transform.localScale.y))/5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
