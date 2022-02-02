using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This Script is used to Spawn in the player charecter on death
/// It uses the Spanwner Class Which Simply Helps With Varables and is used for Enemy Ai and friendly Ai 
/// It work like a Singly Linked list in a way
/// I input a series of Lives or Objects and then move and delete them. 
/// This is a way to have player lives will be represented in Game as other robots replacing them. 
/// 
/// We first set the Number of Object that will be used as Lives.
/// So for the game we have 3. 
/// 
/// For the Player respawn Right no death is just Falling. 
/// Later on it includes. A death screen and a way to add more lives. 
/// Also Planning for this to connect and work with a Healh Bar
/// </summary>
public class CharecterSwapping : AbstractPlayer 
{
    private GameObject tempGameObject;

    public GameObject SwapCharecter()
    {
        playerControls.transform.position = numOfRobotsLivesInUse[index].transform.position;
        tempGameObject = numOfRobotsLivesInUse[index];
        Spirte = numOfRobotsLivesInUse[index];
        index++;
        return tempGameObject;
    }    
    private int fallingDeath = -10;
    void Update()
    {
        if (playerControls.transform.position.y <= fallingDeath)
        {
            Destroy(SwapCharecter());
        }
    }
}
