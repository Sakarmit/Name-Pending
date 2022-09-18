using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public float yPosOffset;
    private float bottomLimit;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.y += yPosOffset;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        if(bottomLimit < transform.position.y - 2)
            bottomLimit = transform.position.y - 2;

        transform.position = new ( 0, Mathf.Clamp(transform.position.y, bottomLimit, float.PositiveInfinity), 0 );
        
        if(endPos.y < bottomLimit - 8)
        {
            GameOver.triggerGameOver();
        }
    }

}
