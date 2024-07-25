using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class PlatformPooler : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;

    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private GameObject deathPlatformPrefab;



    private List<GameObject> platformList = new List<GameObject>();

    private Vector2 platformPosition;   
    private Vector2 playerPosition;

    [SerializeField] private float distanceBetweenPlatforms;
    
    void Start()
    {
        GeneratePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (platformList[platformList.Count - 1].transform.position.y < Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            PlacePlatform();
        }
    }

    void GeneratePlatform()
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        platformList.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<PlatformController>().SetMovement = true;
        for (int i = 0; i < 8; i++) 
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platformList.Add(platform);
            platform.GetComponent<PlatformController>().SetMovement = true;
            NextPlatformPosition();
        }

        GameObject deathPlatform = Instantiate(deathPlatformPrefab, platformPosition, Quaternion.identity);
        deathPlatform.GetComponent<PlatformDeathController>().SetMovement = true;
        platformList.Add(deathPlatform);
        NextPlatformPosition();
    }


    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platformList[i + 5];
            platformList[i + 5] = platformList[i];
            platformList[i] = temp;
            platformList[i + 5].transform.position = platformPosition;
            NextPlatformPosition(); 
        }
    }
    
    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatforms;
        float random = UnityEngine.Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;
        }
    }

}
