using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public PlatformManager platformManager;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Score: " + (platformManager.currentPlatformNumber - 8).ToString();
    }
}
