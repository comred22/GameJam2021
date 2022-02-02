using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Respawn : Spawner
{
    private string DeathScene;
    public void charecterDies()
    {
        SceneManager.LoadScene(DeathScene);
        
    }
}
