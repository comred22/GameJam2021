using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpawner : Spawner
{

    [SerializeField] private Color spawnColor;
    [SerializeField] private int spawnAmount;
    //Let's call override Spawn method in Start
    private void Start()
    {
        Spawn();
    }

    //Overriding base class method
    protected override void Spawn()
    {
        for (var i = 0; i < spawnAmount; i++)
        {
            //Calling base class method without override
            base.Spawn();
            var enemyRenderer = spawnedObject.GetComponent<Renderer>();
            enemyRenderer.material.color = spawnColor;
        }
    }
}