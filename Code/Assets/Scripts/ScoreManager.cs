using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointPerSec;
    public bool scoreIncr;

	
	void Start () {
        if (PlayerPrefs.HasKey("HighScore")) {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	
	void Update () {
        if (scoreIncr){
            scoreCount += pointPerSec * Time.deltaTime;
        }
        if (scoreCount > hiScoreCount) {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
	}

    public void AddScore(int pointAdd) {
        scoreCount += pointAdd;
    }
}
