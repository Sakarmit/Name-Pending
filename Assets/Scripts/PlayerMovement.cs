using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;

    private float horizontalMovement = 0;
    private float verticalMovement = 0;
    
    float movementSpeed = 10f;
    float jumpSpeed = 17.5f;

    // Start is called before the first frame update.
    void Start()
    {
        // set rb to the Rigidbody component on the circle
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Player jumping
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        rb.gravityScale = 5;
 
    }

    void Update()
    {
        //Gets User Inputs A/Left and D/Right
        horizontalMovement = Input.GetAxis("Horizontal");
        //Gets User Inputs W/Up and S/Down
        verticalMovement = Input.GetAxis("Vertical");

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


    }
    void FixedUpdate()
    {

        // Player Falling
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 10;
        }

        //Player X-Axis Movement
        if (horizontalMovement != 0)
        {
            rb.velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
        } 
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
    }

    //Uses BoxCast to Detect if Platform Layer Object is just under the player
    /*private bool IsGrounded()
    {
        float extraDistance = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraDistance, platformLayerMask);
        return raycastHit.collider != null;
    }*/
}
