using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D rb;
    public float speed = 5f;
    private float movement = 0f;
    public float jumpVelocity;
    string buttonPressed;
    private float animationSpeed = 0.0f;
    public static int direction = 1; 
    private BoxCollider2D boxCollider;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(animationSpeed));
        Vector3 charecterScale = transform.localScale;
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            charecterScale.x = 10;
            animationSpeed = 1.0f;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
        else if (movement < 0f)
        {
            charecterScale.x = -10;
            animationSpeed = 1.0f;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        transform.localScale = charecterScale;
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        }
        else
        {
            buttonPressed = null;
        }
        if (!Input.anyKey)
        {
            animationSpeed = 0.0f;
        }
    }

    private bool isGrounded()
    {

        RaycastHit2D hits = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);//Center Size and 0
        return hits.collider != null;

    }

}


// if (Input.GetKeyDown(KeyCode.E))
//  {
//  isDashing = true;
//   createDash.TriggerAbility();
//}