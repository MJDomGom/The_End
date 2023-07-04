using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDelete : MonoBehaviour {

    public GameObject platformDeletePoint;
	
	void Start () {
        platformDeletePoint = GameObject.Find("PlatformPointDelete");
	}
	
	
	void Update () {

        if (transform.position.x < platformDeletePoint.transform.position.x) {
            
            gameObject.SetActive(false);
            
        }
	}
}
