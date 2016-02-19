using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy_prefab;
	public float speed = 5.0f;
	public float padding = 1.0f;
	public float width = 10.0f;
	public float height = 5.0f;
	
	private bool moving_right = false;
	float xmin;
	float xmax;


	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemy_prefab, child.position, Quaternion.identity) as GameObject;	
			enemy.transform.parent = child;
		}
		
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left_most = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 right_most = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = left_most.x;
		xmax = right_most.x;
	}
	
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (moving_right) {
			transform.position += Vector3.right * speed * Time.deltaTime;	
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float right_edge = transform.position.x + (0.5f * width);
		float left_edge = transform.position.x - (0.5f * width);
		
		if (left_edge < xmin || right_edge > xmax) {
			moving_right = !moving_right;
		}
	}
}
