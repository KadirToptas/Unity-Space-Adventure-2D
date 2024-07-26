using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformController : MonoBehaviour
{
    private PolygonCollider2D _polygonCollider2D;

    private bool _isMoving ;

    private float min, max;

    private float randomMoveSpeed;
    
    public bool SetMovement
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
        }
    }
    
    void Start()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (SettingsPrefs.ReadEasyValue() == 1)
        {
            randomMoveSpeed = Random.Range(0.2f, 0.8f);

        }

        if (SettingsPrefs.ReadNormalValue() == 1)
        {
            randomMoveSpeed = Random.Range(0.5f, 1.0f);

        }

        if (SettingsPrefs.ReadHardValue() == 1)
        {
            randomMoveSpeed = Random.Range(0.8f, 1.5f);

        }

        float objectWidth = _polygonCollider2D.bounds.size.x / 2;
        
        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomMoveSpeed, max - min)+min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundCheck"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerController>().ResetJumpCount();
        }
    }
}
