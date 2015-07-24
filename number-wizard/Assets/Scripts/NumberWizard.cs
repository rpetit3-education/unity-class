using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int min;
	int max;
	int guess;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
		    max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I won!");
			StartGame();
		} 
	}
	
	void StartGame() {
	    print ("++++++++++++++++++++++++");
		print ("Welcome to Number Wizard");
		print ("You pick a number and I'll guess it!");
		
		max = 1000;
		min = 0;
		guess = (max + min) / 2;
		
		print ("The highest number you can pick is " + max);
		max++;
		print ("The lowest number you can pick is " + min);
		
		print ("Is the number you've picked higher or lower than "+ guess +"?");
		print ("Up arrow for higher, down arrow for lower, and enter for correct.");
		
	}
	
	void NextGuess() {
		guess = (max + min) / 2;
		print ("Is the number you've picked higher or lower than "+ guess +"?");
	}
}
