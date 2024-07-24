using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float acceleration;

    [SerializeField] private float maxSpeed;

    private bool _isMoving = true;
    
    void Start()
    {
        moveSpeed = 0.5f;
        acceleration = 0.05f;
        maxSpeed = 2.0f;
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
}
