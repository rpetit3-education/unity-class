using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int min;
	int max;
	int guess;
	int max_guess = 10;
	int total_guess = 0;
	
	public Text text;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 1001;	
		NextGuess();
	}

	public void GuessLower() {
		max = guess;
		NextGuess();
	}
			
	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	
	// Update guess
	void NextGuess () {
		max_guess = max_guess - 1;
		guess = Random.Range(min, max);
		text.text = guess.ToString();
		
		if (max_guess <= 0) {
			Application.LoadLevel("win");
		}
	}
}
