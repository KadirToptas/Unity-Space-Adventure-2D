using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteWideness = sr.size.x;
        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWideness = screenHeight / Screen.height * Screen.width;
        tempScale.x = screenWideness / spriteWideness;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
