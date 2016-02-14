using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {
		start, new_island, visit_island, new_encounter, find_food, pick_fight,
		run_away, have_party, the_end, the_end_disappointed, the_end_freeze
	}
	
	private States current_state;
	// Use this for initialization
	void Start () {
		current_state = States.start;
	}
	
	// Update is called once per frame
	void Update () {
		if (current_state == States.start){
			state_start();
		} else if (current_state == States.new_island) {
			state_new_island();
		} else if (current_state == States.the_end_disappointed) {
			state_the_end_disappointed();
		} else if (current_state == States.visit_island) {
			state_visit_island();
		} else if (current_state == States.new_encounter) {
			state_new_encounter();
		} else if (current_state == States.the_end_freeze) {
			state_the_end_freeze();
		} else if (current_state == States.find_food) {
			state_find_food();
		} else if (current_state == States.run_away) {
			state_the_end_freeze();
		} else if (current_state == States.pick_fight) {
			state_pick_fight();
		} else if (current_state == States.the_end) {
			state_the_end();
		}
	}
	
	void state_start() {
		text.text = "The Straw Hats are enjoying yet another day out at sea. It has been " +
		            "an unusually calm day in the New World. As you may have suspected, " +
		            "that is all about to come to an end.\n\n" +
		            "Press the Space Bar to continue.";
		            
		if (Input.GetKeyDown(KeyCode.Space)) {
			current_state = States.new_island;
		}
	}
	
	void state_new_island(){
		text.text = "Heyyyyy! Look there's a island in the distance. Wow, half the island is " +
		            "ice and the other half is fire! HOW COOL!!!\n\n" +
		            "Press 'V' to visit the island, or 'C' to continue your voyage.";
		            
        if (Input.GetKeyDown(KeyCode.V)) {
        	current_state = States.visit_island;
        } else if (Input.GetKeyDown(KeyCode.C)) {
        	current_state = States.the_end_disappointed;
        }
	}
	
	void state_visit_island() {
		text.text = "A few members of the Straw Hat crew set out to visit the island. Luffy, " +
		            "Zoro, Robin and Usopp use the Going Merry II and grab a bite to eat " +
		            "while they venture to the island.\n\n" +
				    "Press the Space Bar to continue.";
				    
		if (Input.GetKeyDown(KeyCode.Space)) {
			current_state = States.new_encounter;
		}
	}
	
	void state_the_end_disappointed() {
		text.text = "The adventure to the new island was over before it even began...\n\n" +
			"Press Space Bar to restart the story.";
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			current_state = States.start;
		} 
	}
	
	void state_new_encounter() {
		text.text = "The Straw Hats land on the island and begin exploring. They soon come upon " +
		            "an unexpected being...\n\n" +
		            "Press 'R' to run away or press 'S' to stick around.";
		            
        if (Input.GetKeyDown(KeyCode.R)) {
        	current_state = States.run_away;
        } else if (Input.GetKeyDown(KeyCode.S)) {
        	current_state = States.find_food;
        }
	}
	
	void state_the_end_freeze() {
		text.text = "At some point during the escape a wrong turn was made. The Strawhats " + 
			        "ventured to the ice side of the island and froze.\n\n" +
				    "Press Space Bar to restart the story.";
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			current_state = States.start;
		} 
	}
	
	void state_find_food() {
		text.text = "A mystical fire breathing dragon had appeared in front of the Straw Hats. In " +
		            "true Straw Hat fashion, Luffy decides he must taste this dragon.\n\n" +
		            "Press Space Bar to pick a fight with the dragon.";
		
        if (Input.GetKeyDown(KeyCode.Space)) {
        	current_state = States.pick_fight;
        }
	}
	
	void state_pick_fight() {
		text.text = "Something like this dragon needs to be sliced!\n\n" +
		            "Press Space Bar to continue.";
        
        if (Input.GetKeyDown(KeyCode.Space)) {
        	current_state = States.the_end;
        }
	}
	
	void state_the_end() {
		text.text = "An adventurous day which includes dragon meat can only be topped off with a " +
		            "celebration!\n\n" +
				    "Press Space Bar to restart the story.";
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			current_state = States.start;
		} 
	}
}
