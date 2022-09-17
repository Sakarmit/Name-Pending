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

    int currentPlatformNumber = 0;
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
        if (lowestObject.transform.localPosition.y < player.position.y - 10)
        {
            Destroy(lowestObject);
            createPlatform();
        }
    }
    private void createPlatform()
    {

        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(Random.Range(-10f, 9f), 4 * currentPlatformNumber - 1, 0), Quaternion.identity, parent);
        newPlatform.name = currentPlatformNumber.ToString();
        currentPlatformNumber++;
    }
}
