using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformDeathController : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

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
        _boxCollider2D = GetComponent<BoxCollider2D>();
        randomMoveSpeed = Random.Range(0.5f, 1.0f);

        float objectWidth = _boxCollider2D.bounds.size.x / 2;
        
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
            FindObjectOfType<GameController>().FinishGame();
        }
    }
}
