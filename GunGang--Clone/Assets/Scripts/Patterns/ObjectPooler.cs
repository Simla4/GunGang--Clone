using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoSingleton<ObjectPooler>
{
    #region Variables
    
    [Serializable]
    public struct Pool
    {
        public GameObject objPrefab;
        public List<GameObject> activeList;
        public List<GameObject> inactiveList;
    }

    [SerializeField] private List<Pool> pools = null;

    #endregion

    #region Other Methods

    public GameObject SpanwObject(int objType)
    {
        GameObject spawnedObj = null;
        
        if(pools[objType].inactiveList.Count > 0)
        { 
            spawnedObj = pools[objType].inactiveList[0];

            pools[objType].inactiveList.RemoveAt(0);
        }
        else
        {
            spawnedObj = Instantiate(pools[objType].objPrefab);
        }
        
        spawnedObj.SetActive(true);
        
        pools[objType].activeList.Add(spawnedObj);
        
        return spawnedObj;

    }

    public void RemoveObject(GameObject obj, int objType)
    {
        pools[objType].activeList.Remove(obj);
        
        pools[objType].inactiveList.Add(obj);
        obj.SetActive(false);
    }

    #endregion
}
