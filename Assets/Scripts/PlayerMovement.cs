using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementForce = (float)0.05;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, movementForce, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementForce, 0, 0);
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
