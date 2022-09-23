using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Light_System : MonoBehaviour
{

    public GameObject globalLight;
    private Boolean lightOn;

    private GameObject lightBar;

    private float lightBarMaxSize;
    [SerializeField] private float currentLightBarPercent = 0f;
    public float  lightBarGrowSpeed = 0.0005f;
    public float lightBarDecaySpeed = 0.001f;

    void Start()
    {
        toggleLight(true);
        lightBar = this.gameObject;
        lightBarMaxSize = lightBar.transform.localScale.y;
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
        if (lightOn && currentLightBarPercent < 1)
        {
            currentLightBarPercent += lightBarGrowSpeed;
        }
        else if (!lightOn && currentLightBarPercent >= 0)
        {
            currentLightBarPercent -= lightBarDecaySpeed;
        }
        else if(currentLightBarPercent > 1)
        {
            GameOver.triggerGameOver();
        }
        lightBar.transform.localScale = new Vector3( lightBar.transform.localScale.x ,currentLightBarPercent * lightBarMaxSize, 1);
        lightBar.transform.localPosition = new Vector3(lightBar.transform.localPosition.x,lightBarMaxSize/2 - (currentLightBarPercent * lightBarMaxSize)/2, lightBar.transform.localPosition.z);

    }
}
