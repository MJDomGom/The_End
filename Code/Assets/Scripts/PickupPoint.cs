using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoint : MonoBehaviour {

    public int scoreToGive;
    private ScoreManager scoreManager;
    private AudioSource coinSound;

	
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("Pickup_Coin").GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "Player") {
            scoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            coinSound.Play();
        }
    }
}
