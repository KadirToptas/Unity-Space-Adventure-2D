using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        randomMoveSpeed = Random.Range(0.5f, 1.0f);

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
}