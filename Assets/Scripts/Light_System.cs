using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_System : MonoBehaviour
{

    public GameObject globalLight;
    private Boolean lightOn;

    private GameObject lightBar;

    private float lightBarMaxSize = 23.5f;
    private float currentLightBarPercent = 0f;
    public float lightBarGrowSpeed = 0.001f;
    public float lightBarDecaySpeed = 0.001f;


    void Start()
    {
        toggleLight(false);
        lightBar = this.gameObject;
    }

    
    void Update()
    {
        //Calls toggleLight when space key is pressed
        if (Input.GetKeyDown("space"))
        {
            toggleLight(!lightOn);
        }

        updateLightBar();
    }

    //toggles globalLight and lightOn variable
    void toggleLight(bool state)
    {
        if (state)
        {
            globalLight.SetActive(true);
            lightOn = true;
        }
        else
        {
            globalLight.SetActive(false);
            lightOn = false;
        }
    }


    void updateLightBar()
    {
        if (lightOn && currentLightBarPercent <= 1)
        {
            currentLightBarPercent += lightBarGrowSpeed;
        }
        else if (!lightOn && currentLightBarPercent >= 0)
        {
            currentLightBarPercent -= lightBarDecaySpeed;
        }
        lightBar.transform.localScale = new Vector3(currentLightBarPercent * lightBarMaxSize, lightBar.transform.localScale.y, 1);

    }
}
