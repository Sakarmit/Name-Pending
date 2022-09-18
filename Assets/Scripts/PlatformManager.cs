using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{

    [SerializeField] GameObject startingPlatform;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Transform player;

    public int currentPlatformNumber = 0;
    private float currentPlatformXPosition;
    private GameObject lowestObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            createPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        lowestObject = transform.GetChild(0).gameObject;
        if (lowestObject.transform.localPosition.y < player.position.y - 4)
        {
            Destroy(lowestObject);
            createPlatform();
        }
    }
    private void createPlatform()
    {

        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(Random.Range(-10f, 9f), 4 * currentPlatformNumber - 2, 2), Quaternion.identity, parent);
        newPlatform.name = currentPlatformNumber.ToString();
        currentPlatformXPosition = newPlatform.transform.position.x;
        currentPlatformNumber++;
    }

    float getRandomXPosition()
    {
        float randomNumber;

        do
        {
            randomNumber = Random.Range(-10f, 14f);
        } 
        while (Mathf.Abs(randomNumber - currentPlatformXPosition) < 16);
        
        return randomNumber;
    }
}
