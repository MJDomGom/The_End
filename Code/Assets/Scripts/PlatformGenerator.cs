using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platformGen;
    public Transform generationPoint;
    private float distancePlatform;
    private int platformSelector;
    private float[] platformWidth;
    public float distanceMin;
    public float distanceMax;
    public ObjectPool[] theObjectPools;
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    private CoinGenerator coinGenerator;
    public float randomCoin;

    

	
	void Start () {
        platformWidth = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++) {
            platformWidth[i] = theObjectPools[i].poolObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        coinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	
	void Update () {
        if (transform.position.x < generationPoint.position.x) {
            distancePlatform = Random.Range(distanceMin, distanceMax);
            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight) {
                heightChange = minHeight;
            }
            transform.position = new Vector3(transform.position.x + (platformWidth[platformSelector] / 2) + distancePlatform, heightChange, transform.position.z);
           
          
    
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            if (Random.Range(0f, 100f) < randomCoin){
                coinGenerator.SpawnCoin(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            transform.position = new Vector3(transform.position.x + (platformWidth[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
