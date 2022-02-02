using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbstractPlayerAblties
{
    private  float movement = 0f;
    public Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public GameObject dashEffect;
    void Start()
    {

    }
    private void Update()
    {

    }
    public override void Initialize(GameObject b1)
    {

    }
    public override void TriggerAbility()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {


            rb.AddForce(new Vector2(dashSpeed, 0), ForceMode2D.Force);
            //Instantiate(dashEffect);

        }
        else if (movement < 0f)
        {

            rb.AddForce(new Vector2(-dashSpeed, 0), ForceMode2D.Force);
            //Instantiate(dashEffect);
        }

    }
 
}
