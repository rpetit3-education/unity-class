using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {

	public GameObject enemy_prefab;
	public float spawn_delay = 0.5f;
	public float speed = 5.0f;
	public float padding = 1.0f;
	public float width = 10.0f;
	public float height = 5.0f;
	
	private bool moving_right = false;
	float xmin;
	float xmax;


	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left_most = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 right_most = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = left_most.x;
		xmax = right_most.x;
		
		SpawnUntilFull();
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
		
		if (left_edge < xmin ) {
			moving_right = true;
		} else if (right_edge > xmax) {
			moving_right = false;
		}
		
		if (AllMembersDead()) {
			Debug.Log ("Empty Formation, respawning...");
			SpawnUntilFull();
		}
		
		
	}
	
	void SpawnEnemies() {
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemy_prefab, child.position, Quaternion.identity) as GameObject;	
			enemy.transform.parent = child;
		}
	}
	
	void SpawnUntilFull() {
		Transform free_postion = NextFreePosition();
		if (free_postion) {
			GameObject enemy = Instantiate(enemy_prefab, free_postion.position, Quaternion.identity) as GameObject;	
			enemy.transform.parent = free_postion;
		}
		
		if (NextFreePosition()) {
			Invoke("SpawnUntilFull", spawn_delay);
		}
	}
	
	Transform NextFreePosition () {
		foreach(Transform position in transform) {
			if (position.childCount == 0) {
				return position;
			}
		}
		
		return null;
	}
	
	bool AllMembersDead () {
		foreach(Transform position in transform) {
			if (position.childCount > 0) {
				return false;
			}
		}
		
		return true;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Debug.Log("Hit Enemy");
	}
}
