using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Finite State Machine Abstract Class for Handling AI bahvoir states
/// This is an abstract class that handles the AI of the NPC 
/// It will have 3 states 
/// Check the players postion
/// Patrol between Nodes 
/// Then shoot the player
/// </summary>
public abstract class FSM : MonoBehaviour
{
    //Player Transform 
    protected Transform playerTransform;

    // Destination of our NPC destPos  = destination postion 
    protected Vector3 destPos;

    // List of nodes to patrol 
    protected GameObject[] pointList;

    // attack and fire rate
    protected float shootRate;
    protected float elapsedTime;

    public Transform bulletSpawnPoint { get; set; }

    protected virtual void Initialize(){}
    protected virtual void FSMUpdate() {}
    protected virtual void FSMFixedUpdate() { }
    void Start()
    {
        Initialize();
    }
    void Update()
    {
        FSMUpdate();
    }
    void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}
