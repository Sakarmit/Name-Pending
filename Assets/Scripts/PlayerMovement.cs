using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;

    private float horizontalMovement = 0;
    private float verticalMovement = 0;
    
    float movementSpeed = 5f;
    float jumpSpeed = 8f;

    // Start is called before the first frame update.
    void Start()
    {
        // set rb to the Rigidbody component on the circle
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Gets User Inputs A/Left and D/Right
        horizontalMovement = Input.GetAxis("Horizontal");
        //Gets User Inputs W/Up and S/Down
        verticalMovement = Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {
        // Player Jumping
        if (IsGrounded() && verticalMovement > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        //Player X-Axis Movement
        if(horizontalMovement != 0)
        {
            rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
    }

    //Uses BoxCast to Detect if Platform Layer Object is just under the player
    private bool IsGrounded()
    {
        float extraDistance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraDistance, platformLayerMask);
        return raycastHit.collider != null;
    }
}
