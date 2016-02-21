using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private Text text;
	public static int score;
	
	void Start () {
		text = GetComponent<Text>();
		text.text = score.ToString();
	}
	
	public void Score (int points) {
		score += points;
		text.text = score.ToString();
	}
	
	public static void Reset () {
		score = 0;
	}

}
