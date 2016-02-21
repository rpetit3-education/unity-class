using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject projectile_prefab;
	private ScoreKeeper score_keeper;
	public AudioClip fire_sound;
	public AudioClip explosion;

	public float projectile_speed = -10.0f;
	public float health = 150f;
	public float shots_per_second = 0.5f;
	public int score_value = 100;
	
	void Start() {
		score_keeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update() {
		float probability = Time.deltaTime * shots_per_second;
		if (Random.value < probability) {
			Fire();
		}
	}
	
	void Fire() {
		GameObject projectile = Instantiate(projectile_prefab, transform.position, Quaternion.identity) as GameObject;
		projectile.rigidbody2D.velocity = new Vector3(0, projectile_speed, 0);
		projectile.GetComponent<AudioSource>().Play();
		AudioSource.PlayClipAtPoint(fire_sound, transform.position);
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
		AudioSource.PlayClipAtPoint(explosion, transform.position);
		Destroy(gameObject);
		score_keeper.Score(score_value);
	}
}
