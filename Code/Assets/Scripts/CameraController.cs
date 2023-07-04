using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController Player;
    private Vector3 lastPosition;
    private float distanceToMove;

	
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        lastPosition = Player.transform.position;
    }
	
	
	void Update () {
        distanceToMove = Player.transform.position.x - lastPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPosition = Player.transform.position;
	}
}
