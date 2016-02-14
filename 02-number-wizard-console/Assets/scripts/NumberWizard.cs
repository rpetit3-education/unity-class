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
		if (Input.GetKeyDown(KeyCode.H)){
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.L)) {
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("Wow you really picked " + guess + "!?!? " + 
			       "At least give me a challenge next time!");
			StartGame();
		}
	}
	
	// Start the game
	void StartGame () {
		min = 1;
		max = 1000;
				
		print ("=========================");
		print ("=========================");
		print ("Welcome to Number Wizard!");
		print ("Rules of the game, you pick a number in your head and I guess it! No much else to it.");
		print ("Do note though, your number should be between " + min + " and " + max + "!");
		
		Input.inputString();
		
		max = max + 1;
		NextGuess();
	}
	
	// Update guess
	void NextGuess () {
		guess = Random.Range(min, max);
		HelpMessage();
	}
	
	// Simple help mesasage
	void HelpMessage () {
		print ("Is your number higher or lower than " + guess + "?");
		print ("Please use 'H' for higher, 'L' for lower and Enter' for equal)");
	}
}
