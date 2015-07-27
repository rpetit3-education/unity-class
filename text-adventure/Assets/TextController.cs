using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {
		intro,
		lab_tech,
		no_lab_tech,
		wait_lab_tech_1,
		wait_lab_tech_2,
		begin_prep_1,
		begin_analysis,
		talk_to_tech,
		end_game
	};
	private States my_state;

	// Use this for initialization
	void Start () {
		start_game();
	}
	
	void start_game () {
		text.text = "You're a highly trained researcher at the CDC. To date you " +
			        "have over 20 years working with some of the most deadly " +
				    "diseases, including the most recent Ebola outbreak.\n\n" +
				    "You have recently been given new samples of a highly lethal " +
				    "strain of the common cold virus. Already 80 people have died " +
				    "in a small country town.\n\n" + 
				    "Press space bar to begin the story...";
		my_state = States.intro;
	}
	
	// Update is called once per frame
	void Update () {
		print(my_state);
		if (my_state == States.intro) { intro(); }
		else if (my_state == States.lab_tech) { lab_tech(); }
		else if (my_state == States.no_lab_tech) { no_lab_tech(); }
		else if (my_state == States.begin_prep_1) { begin_prep_1(); }
		else if (my_state == States.wait_lab_tech_1) { wait_lab_tech_1(); }
		else if (my_state == States.wait_lab_tech_2) { wait_lab_tech_2(); }
		else if (my_state == States.end_game) { end_game(); }
	}
	
	void intro () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			my_state = States.lab_tech;
			text.text = "The samples are still under dry ice and ready to be analyzed. " +
			            "You're lab technician hasn't arrived yet. It is still a " +
			            "little early, and she's seldom ever late. Sometimes it is " +
			            "helpful to have help when dealing with such a lethal disease. " +
			            "This is not to say you can't complete the analysis yourself. " +
			            "You are fully confident in your work.\n\n" +
			            "Press (B) to begin analysis, or (W) to wait for your lab tech.";
			   
		} 
	}
	
	void end_game () {
		if (Input.GetKeyDown(KeyCode.R)) {
			start_game();
		} 
	} 
	
	void lab_tech () {
		if (Input.GetKeyDown(KeyCode.B)) {
			my_state = States.no_lab_tech;
			text.text = "Your lab tech should arrive in the next few minutes, so you decide " +
			            "to get started with the analysis. At the moment you aren't really " +
			            "doing anything dangerous. You take the vials out of dry ice and lable " +
			            "them accordningly. One of the vials is left on ice at the benchtop and " +
			            "the rest are placed in an isolated -80 freezer. You are now ready to " + 
			            "begin prepping the samples, but your lab tech still hasn't arrived.\n\n" +
					    "Press (B) to begin sample prep, or (W) to wait for your lab tech.";
		} else if (Input.GetKeyDown(KeyCode.W)) {
			my_state = States.wait_lab_tech_1;
			text.text = "Your lab tech arrives right on time as usual. You exchange morning " +
			            "greetings, all is well. The two of sit down and create a gameplan " +
			            "for the day. You will get prepped for analysis (biohazard suit) " +
			            "and she will prepare the samples. When the meeting is over you notice " +
			            "something is off, you lab tech seems a little preoccupied.\n\n" +
			            "Press (S) to suit up and begin analysis or (T) to sit down and talk " +
			            "to your lab tech.";
		}
	}
	
	void no_lab_tech () {
		if (Input.GetKeyDown(KeyCode.B)) {
			my_state = States.begin_prep_1;
			text.text = "You begin prepping the samples for analysis. You are a little rusty but " +
			            "quickly get a handle on it. After prepping the samples, begin to suit up. " +
			            "Just as you are suiting up, your lab tech arrives. She is most apologetic and " +
			            "explains she was in a small fender binder on the way in. You make sure " +
			            "everything is alright. She confirms it is and notices you have prepped the " +
			            "samples already. She askes if you would like her to double check to make sure " +
			            "everything is how it should be.\n\n" + 
			            "Press (M) to move along with the analysis, or (C) to allow the lab tech to " +
			            "double check your sample prep.";
			            
		} else if (Input.GetKeyDown(KeyCode.W)) {
			my_state = States.wait_lab_tech_2;
			text.text = "Your lab tech is now an hour late, this is most unusual. You decide to " +
			            "call her cell phone. No answer. Within seconds you receive a call from " +
			            "your supervisor. Your lab tech, who has worked for you the last ten years, " +
			            "was killed in a car wreck on the way to work today. You are overcome with " +
			            "emotions. But there are samples of a very deadly disease you must analyze. " +
			            "Understanding the situation, your supervisor suggests you take some time off " +
			            "but will leave that decision up to you.\n\n" +
			            "Press (C) to continue your analysis yourself, or (T) to take some time off " + 
			            "and allow a colleague to handle it.";
		}
	}
	
	void begin_prep_1 () {
		if (Input.GetKeyDown(KeyCode.M)) {
			my_state = States.end_game;
			text.text = "Ignoring your lab techs request to allow her to double check your sample prep, " +
			            "you continue with the anlaysis. Your complete the analysis, but a few days later " +
			            "begin feeling under the weather. Much of the symptoms are similar to the lethal " +
			            "disease to had been working on. You call your lab tech and review tghe sample prep " +
			            "protocol with her. She quickly finds a mistake, you failed to inactivate the viruses. " +
			            "Following protocol you place your self in isolation and notify the appropriate people. " +
			            "A few days later you die of the disease.\n\n" +
			            "Press (R) to restart the game.";
			
		} else if (Input.GetKeyDown(KeyCode.C)) {
			my_state = States.end_game;
			text.text = "You sit down with your lab tech and explain the steps taken and how exactly " +
			            "you prepared the samples. She notices and one step you misread the amount " +
			            "deactivation solution to administer to the sample. Upon further analysis, she " +
			            "confirms some of the viruses were still viable. You thank the lab tech and " +
			            "tell her its great to have her around. A few weeks later the two of you make " +
			            "a breakthrough and finally find a cure to the disease.\n\n" +
			            "Press (R) to restart the game.";
		}
	}
	
	void wait_lab_tech_1 () {
		if (Input.GetKeyDown(KeyCode.S)) {
			my_state = States.end_game;
			text.text = "You've decided what ever is bothering your lab tech is not of importance. You order" +
			            "your lab tech to get to work. Fully trusting she will follow protocol, you suit up. " + 
			            "As the lab tech is prepping the sample, she is overcome with grief and begins crying. " +
			            "During this she accidently drops the vial onto her clothes. She quickly strips off " +
			            "her clothes and undergoes the disinfection protocol. Unfortunately it was too late, " +
			            "your labe tech become infected with the disease and dies a few days later.\n\n" +
			            "Press (R) to restart the game.";
		} else if (Input.GetKeyDown(KeyCode.T)) {
			my_state = States.end_game;
			text.text = "You sit and talk with your lab tech. A old friend of hers has died from the " +
			            "disease you must analyze. You tell her a story of a very similar situation early " +
			            "in your career. You once lost a friend to an unknown disease, this motivated you " +
			            "to get into the field you are in. This seems to help focus your lab tech. Now " +
			            "focused on the task at hand, you and your lab tech follow your protocol. Have a " +
			            "weeks worth of work, the two of you finally determine a cure to the disease. In honor " +
			            "of your lab tech's friend, you give each sample a tag of the friend's inititals.\n\n" +
			            "Press (R) to restart the game.";
		}
	}
	
	void wait_lab_tech_2 () {
		if (Input.GetKeyDown(KeyCode.C)) {
			my_state = States.end_game;
			text.text = "You continue the analysis your self. But you have to take a number of breaks to " +
			            "grieve your loss. You compose your self and continue pressing along. As your are " +
			            "working in the biohazard suit, you notice a small tear in the suit. How did this " +
			            "happen? You quickly press the alarm and are placed in isolation. A few weeks later " +
			            "you die of the disease you were working on. It was transmitted through the air, the " +
			            "tear in your suit allowed you to be come infected. A few days later you die of the " +
			            "disease.\n\n" +
			            "Press (R) to restart the game.";
		} else if (Input.GetKeyDown(KeyCode.T)) {
			my_state = States.end_game;
			text.text = "Overcome with grief, you decide to take the day off. It was probably for " +
			            "for the better. Your colleague followed your protocol, and was able to " +
			            "determine a treatment for the disease. Application of this treatment allowed " +
			            "this outbreak to remain and isolated incident. You took the next two weeks off " +
			            "and soon decided in was time to get back to work. You are met with condolences, " +
			            "but are quickly brought to speed on the latest case currently isolated in a " +
			            "remote village of India.\n\n" +
			            "Press (R) to restart the game.";
		}
	}
}
