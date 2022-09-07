using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Switch : MonoBehaviour
{
    public Sprite spriteLightOn;
    public Sprite spriteLightOff;
    public GameObject globalLight;
    
    private SpriteRenderer spriteRenderer;
    private Boolean lightOn;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        toggleState(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            toggleState(!lightOn);
        }
    }

    /*
    void OnMouseDown()
    {
        toggleState(!lightOn);
    }
    */

    //Toggles the light swtich sprite and global light on and off
    void toggleState(bool state)
    {
        if (state)
        {
            globalLight.SetActive(true);
            spriteRenderer.sprite = spriteLightOn;
            lightOn = true;
        }
        else
        {
            globalLight.SetActive(false);
            spriteRenderer.sprite = spriteLightOff;
            lightOn = false;
        }
    }
}
