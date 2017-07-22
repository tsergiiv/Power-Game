using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinPopUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openNextLevel() {
		int currentLevel = LevelController.current.level;
		currentLevel++;
		SceneManager.LoadScene ("Level" + currentLevel);
	}

	public void replayLevel() {
		int currentLevel = LevelController.current.level;
		SceneManager.LoadScene ("Level" + currentLevel);
	}
}
