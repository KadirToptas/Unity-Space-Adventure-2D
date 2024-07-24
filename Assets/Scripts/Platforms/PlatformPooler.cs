using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class PlatformPooler : MonoBehaviour
{

    [SerializeField] private GameObject platformPrefab;

    private List<GameObject> platformList = new List<GameObject>();

    private Vector2 platformPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlatform()
    {
        platformPosition = new Vector2(0, 0);
        for (int i = 0; i < 10; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platformList.Add(platform);
            platform.GetComponent<PlatformController>().SetMovement = true;
        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += 3.0f;
        
    }
}
