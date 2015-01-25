using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class Line : MonoBehaviour {
	public Transform[] links;
	private LineRenderer lrend;
	public bool breakable = true;
	public LayerMask mask;

	// Use this for initialization
	void Start () {
		Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < links.Length; i++) {
			lrend.SetPosition(i,links[i].position);
		}
		if(breakable) {
			Break ();
		}
	}

	void FixedUpdate() {
		if(breakable) {
			for(int i = 0; i < links.Length - 1; i++) {
				if(Physics2D.Linecast(links[i].position,links[i+1].position,mask)) {
					Break ();
				}
			}
		}
	}

	void Break() {
		Transform[] a, b;
		int len = links.Length / 2;
		a = new Transform[len];
		b = new Transform[links.Length - len];
		for(int i = 0; i < len; i++) {
			a[i] = links[i];
		}
		for(int i = len; i < links.Length; i++) {
			b[i - len] = links[i];
		}

		if(len - 1 >= 0) {
			links[len-1].GetComponent<Joint2D>().connectedBody = null;
		}

		links = a;
		breakable = false;
		Setup ();

		Line n = ((GameObject)Instantiate (gameObject)).GetComponent<Line> ();
		n.links = b;
		n.breakable = false;
		n.Setup ();
	}

	public void Setup() {
		lrend = GetComponent<LineRenderer> ();
		lrend.SetWidth (1.0f, 1.0f);
		lrend.SetVertexCount (links.Length);
	}

	
}
