using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platGen;
    private Vector3 platStartPoint;
    public PlayerController Player;
    private Vector3 playerStartPoint;

    private PlatformDelete[] platList;

    private ScoreManager scoreManager;

    public DeathMenu deathScreen;

    public AudioSource BSO;

	
	void Start () {
        platStartPoint = platGen.position;
        playerStartPoint = Player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
        BSO.Play();
	}

    public void RestartGame() {
        scoreManager.scoreIncr = false;
        Player.gameObject.SetActive(false);
        BSO.Stop();
        deathScreen.gameObject.SetActive(true);

        
    }

    public void Reset()
    {
        deathScreen.gameObject.SetActive(false);
        platList = FindObjectsOfType<PlatformDelete>();
        for (int i = 0; i < platList.Length; i++)
        {
            platList[i].gameObject.SetActive(false);
        }
        Player.transform.position = playerStartPoint;
        platGen.position = platStartPoint;
        Player.gameObject.SetActive(true);
        scoreManager.scoreCount = 0;
        scoreManager.scoreIncr = true;
        BSO.Play();
    }

}
