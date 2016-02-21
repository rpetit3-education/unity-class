using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject projectile_prefab;
	public AudioClip fire_sound;
	public float projectile_speed = 20.0f;
	public float firing_rate = 0.2f;
	
	public float player_speed = 15.0f;
	public float player_padding = 1.0f;
	public float health = 250f;
	float xmin;
	float xmax;
	
	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 left_most = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 right_most = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = left_most.x + player_padding;
		xmax = right_most.x - player_padding;
	}
	
	void Fire() {
		GameObject projectile = Instantiate(projectile_prefab, transform.position, Quaternion.identity) as GameObject;
		projectile.rigidbody2D.velocity = new Vector3(0, projectile_speed, 0);
		AudioSource.PlayClipAtPoint(fire_sound, transform.position);
	}	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)){
			// Move Ship Left	
			transform.position += Vector3.left * player_speed * Time.deltaTime;	
		} else if (Input.GetKey(KeyCode.RightArrow)){
			// Move Ship Right
			transform.position += Vector3.right * player_speed * Time.deltaTime;	
		}
		
		// Fire the projectile
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, firing_rate);
		}
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
		
		float new_x = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(new_x, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if (missle) {
			health -= missle.GetDamage();
			missle.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	void Die () {
		LevelManager manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		manager.LoadLevel("GameOver");
		Destroy(gameObject);
	}

}
