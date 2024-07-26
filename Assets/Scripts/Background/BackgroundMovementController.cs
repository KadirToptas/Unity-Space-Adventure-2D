using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementController : MonoBehaviour
{
    private float _backgroundPosition;
    float _distance = 10.24f;
    void Start()
    {
        _backgroundPosition = transform.position.y;
        FindObjectOfType<Planets>().SettlePlanets(_backgroundPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (_backgroundPosition + _distance < Camera.main.transform.position.y)
        {
            SettleBackground();
        }
        
    }

    void SettleBackground()
    {
        _backgroundPosition += (_distance * 2);
        FindObjectOfType<Planets>().SettlePlanets(_backgroundPosition);
        Vector2 newPos = new Vector2(0, _backgroundPosition);
        transform.position = newPos;
    }
}
