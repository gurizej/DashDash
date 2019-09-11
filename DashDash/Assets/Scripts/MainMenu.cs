using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highScoreText;

	// Use this for initialization
	void Start () {
		highScoreText.text = "High Score: " + (int) PlayerPrefs.GetFloat("HighScore");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toGame()
    {
        SceneManager.LoadScene("Game");
    }
}
