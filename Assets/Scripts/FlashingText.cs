using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class FlashingText : MonoBehaviour {
  Text flashingText;
  string textToFlash;

  void Start() {
    flashingText = GetComponent<Text>();
    textToFlash = flashingText.text;
    StartCoroutine(BlinkText());
  }

  public IEnumerator BlinkText() {
    while (true) {
      flashingText.text = "";
      // display blank text for 0.5 seconds
      yield return new WaitForSeconds(.5f);
      // display text for the next 0.5 seconds
      flashingText.text = textToFlash;
      yield return new WaitForSeconds(.5f);
    }
  }
}
