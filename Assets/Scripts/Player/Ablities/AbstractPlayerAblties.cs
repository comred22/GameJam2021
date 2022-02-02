using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// First off we want a way to make multiple ablites
/// Okay So we have a  way to creat ablities this will be our template 
/// we have A name for it
/// We have a Object 
/// We have a sound 
/// a cool down 
/// and ways to trigger the ablity
/// </summary>
public abstract class AbstractPlayerAblties : MonoBehaviour
{
    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aBaseCoolDown = 1f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}
