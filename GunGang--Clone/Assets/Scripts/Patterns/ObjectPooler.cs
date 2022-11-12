using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<GameObject> activeList;
    [SerializeField] private List<GameObject> inactiveList;

    #endregion

    #region Other Methods

    public GameObject SpanwObject(GameObject obj, int poolSize)
    {
        GameObject spawnedObj = null;

        if (activeList.Contains(obj))
        {
            var index = inactiveList.BinarySearch(obj);
            
            spawnedObj = inactiveList[index];
            inactiveList.RemoveAt(index);
            
            spawnedObj.SetActive(true);
            
            activeList.Add(spawnedObj);
            return spawnedObj;
        }
        else
        {
            spawnedObj = Instantiate(obj);
            
            activeList.Add(spawnedObj);
            
            return spawnedObj;
        }
        
    }

    public void RemoveObject(GameObject obj)
    {
        inactiveList.Add(obj);
        obj.SetActive(false);

        activeList.Remove(obj);
    }

    #endregion
}
