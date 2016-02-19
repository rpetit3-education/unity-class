using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool has_started = false;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		Debug.Log(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if (!has_started) {
			// Lock the ball relative top the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonDown(0)) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
				has_started = true;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f));
	
		// Ball does not trigger sound when a brick is destoyed
		// Not 100% sure why, probably due to script execution order
		if (has_started) {
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
