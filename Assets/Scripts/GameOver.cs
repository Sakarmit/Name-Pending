using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOver
{
    static GameObject playerObject;
    public static void triggerGameOver()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerObject.GetComponent<SpriteRenderer>().enabled = false;
        playerObject.GetComponent<Rigidbody2D>().simulated = false;
    }
}
