using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level Request: " + name);
		Brick.breakable_count = 0;
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed() {
		if (Brick.breakable_count <= 0) {
			Brick.breakable_count = 0;
			LoadNextLevel();
		}
	}

	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}
}
