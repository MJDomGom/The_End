using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject poolObject;
    public int pooledAmount;
    public List<GameObject> listObject;
	
	void Start () {
        listObject = new List<GameObject>();
        
            for (int i = 0; i < pooledAmount; i++) {
            GameObject obj = (GameObject)Instantiate(poolObject);
            obj.SetActive(false);
            listObject.Add(obj);
        }
    }
    public GameObject GetPooledObject() {
        for (int i = 0; i < listObject.Count; i++) {
            if (listObject[i] != null)
            {
                if (!listObject[i].activeInHierarchy)
                {
                    return listObject[i];
                }
            }
        }
        GameObject obj = (GameObject)Instantiate(poolObject);
        obj.SetActive(false);
        listObject.Add(obj);
        return obj;
    }
}
	
	

