using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private float yPosOffset = 2;
    private float bottomLimit;

    public float additionalYIncrease;

    bool move;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.y += yPosOffset;
        endPos.z = -10;

        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
        if (bottomLimit > 0)
            bottomLimit += additionalYIncrease;

        if (bottomLimit < transform.position.y - 2)
        {
            bottomLimit = transform.position.y - 2;
        }

        //transform.position = new ( 0, Mathf.Clamp(transform.position.y, bottomLimit, float.PositiveInfinity), 0 );

        if (endPos.y < bottomLimit - 8)
        {
            GameOver.triggerGameOver();
            move = false;
        }

        // Check for start
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            move = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        

        // Scroll up
        if (move == true)
        {
            transform.Translate(0, .04f, 0);
        }
        

        
    }
}
