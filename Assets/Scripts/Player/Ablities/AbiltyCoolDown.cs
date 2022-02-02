using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiltyCoolDown : MonoBehaviour
{
    [SerializeField] protected AbstractPlayerAblties ability;
    public string abilityButtonAxisName = "Fire1";
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;

    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            if (Input.GetButtonDown(abilityButtonAxisName))
            {

                ButtonTriggered();
            }
        }
        else
        {
            CoolDown();
        }
    }
    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
    }
    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        //abilitySource.clip = ability.aSound;
        //abilitySource.Play();
        ability.TriggerAbility();
    }
}
