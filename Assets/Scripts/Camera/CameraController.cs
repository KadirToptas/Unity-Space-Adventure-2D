using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float acceleration;

    [SerializeField] private float maxSpeed;

    private bool _isMoving;
    
    void Start()
    {
        _isMoving = true;
        if (SettingsPrefs.ReadEasyValue() == 1)
        {
            moveSpeed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }

        if (SettingsPrefs.ReadNormalValue() == 1)
        {
            moveSpeed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }

        if (SettingsPrefs.ReadHardValue() == 1)
        {
            moveSpeed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            CameraMover();
        }
    }


    void CameraMover()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        moveSpeed += acceleration * Time.deltaTime;
        if (moveSpeed > maxSpeed)
        {
            moveSpeed = maxSpeed;
        }
    }
    
    public void CameraGameOver()
    {
        _isMoving = false;
    }
}
