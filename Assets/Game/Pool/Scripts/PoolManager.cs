using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool{
    public string name;
    public int amountPool;
    public GameObject prefab;
    public Transform container;
    public List<GameObject> pooledObjects;
}

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance = null;

    [SerializeField] private Pool[] pools;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        for (int i = 0; i < pools.Length; i++) {
            for (int k = 0; k < pools[i].amountPool; k++){
                GameObject newObj = Instantiate(pools[i].prefab, pools[i].container);
                newObj.transform.localPosition = Vector3.zero;
                newObj.SetActive(false);
                pools[i].pooledObjects.Add(newObj);
            }
        }
    }

    public GameObject GetPooledObject(string _object){
        for (int i = 0; i < pools.Length; i++) {
            if(_object.Equals(pools[i].name)){
                for (int k = 0; k < pools[i].pooledObjects.Count; k++) {
                    if(!pools[i].pooledObjects[k].activeInHierarchy){
                        return pools[i].pooledObjects[k];
                    }
                }
            }
        }

        return null;
    }
}
