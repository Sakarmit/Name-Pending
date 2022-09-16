using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver
{
    public static void triggerGameOver()
    {
        GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
    }
}
