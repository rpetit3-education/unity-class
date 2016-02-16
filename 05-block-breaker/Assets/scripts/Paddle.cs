using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool auto_play = true;
	public float left_wall = 0.75f;
	public float right_wall = 15.25f;
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!auto_play) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	float getBlockPosition() {
		return (Input.mousePosition.x / Screen.width * 16);
	}
	
	Vector3 getPaddlePos(float x_pos) {
		return new Vector3(
			Mathf.Clamp(x_pos, left_wall, right_wall),
			this.transform.position.y, 
			this.transform.position.z
		);
	}
	
	void MoveWithMouse() {
		Vector3 paddlePos = getPaddlePos(getBlockPosition());
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 ball_pos = ball.transform.position;
		Vector3 paddlePos = getPaddlePos(ball_pos.x);
		this.transform.position = paddlePos;
	}
}
