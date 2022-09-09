using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // set rb to the Rigidbody component on the circle
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementForce = (float)0.05;
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 400));//* Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementForce*300, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -movementForce, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementForce, 0, 0);
        }
    }
}
