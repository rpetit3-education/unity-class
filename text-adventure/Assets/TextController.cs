using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "BAH BAH BAAAAAA!";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			text.text = "You have just awoken, only to remember today is your final day. " +
			            "10 years ago you were sentenced to death for a crime your did not " +
			            "commit.";
		} 
	}
}
