using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    // is the act of showing Private or protects in the field
    [SerializeField] protected GameObject spawnPrefab;
    [SerializeField] protected Transform spawnPosition;
    [SerializeField] protected GameObject spawnedObject;


    protected virtual void Spawn()
    {
        spawnedObject = Instantiate(spawnPrefab);
        spawnedObject.transform.position = spawnPosition.transform.position;
    }
    public GameObject getControls()
    {
        return spawnPrefab;
    }
    public void setPrefab(GameObject x)
    {
        spawnPrefab = x;
    }
    public Transform getSpawnPostion()
    {
        return spawnPosition;
    }
    public void setSpawnPostion(Transform x)
    {
        spawnPosition = x;
    }
    public GameObject getspawnedObject()
    {
        return spawnedObject;
    }
    public void setSpawnedObject(GameObject x)
    {
        spawnPrefab = x;
    }

}
