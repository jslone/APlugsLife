using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class SoundEffect : MonoBehaviour {

  private bool isPlaying = false;

	// Use this for initialization
	void Start () {
    //source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
	
	}

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Player")) {
      StartCoroutine("WaitAndPlaySound", audio.clip.length);
    }
  }

  IEnumerator WaitAndPlaySound(float waitTime) {
    if (!isPlaying) {
      isPlaying = true;
      audio.Play();
      yield return new WaitForSeconds(waitTime);
      isPlaying = false;
    }
  }
}
