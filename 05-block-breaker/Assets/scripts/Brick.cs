using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	private int times_hit = 0;
	private bool is_breakable;
	
	public AudioClip crack;
	public Sprite[] hit_sprites;
	public GameObject smoke;
	public static int breakable_count = 0;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		is_breakable = (this.tag == "breakable");
		if (is_breakable) {
			breakable_count++;
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (is_breakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		times_hit++;
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		int max_hits = hit_sprites.Length + 1;
		
		if (times_hit >= max_hits) {
			breakable_count--;
			PuffSmoke();
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		GameObject smoke_puff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smoke_puff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int sprite_index = times_hit - 1;
		
		if (hit_sprites[sprite_index] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hit_sprites[sprite_index];
		} else {
			Debug.LogError("Sprite is missing, sprite index: " + sprite_index);
		}
	}
}
