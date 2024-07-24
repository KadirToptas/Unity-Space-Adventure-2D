using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator _animator;

    private Vector2 _velocity;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float acceleration;
    
    [SerializeField] private float slowingDown;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        KeyboardController();
    }

    void KeyboardController()
    {
        float movementInput = Input.GetAxis("Horizontal");

        if (movementInput > 0)
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * moveSpeed, acceleration * Time.deltaTime);
            _animator.SetBool("Walk", true);
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x); // Yüzü sağa döndür
            transform.localScale = newScale;
        }
        else if (movementInput < 0)
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * moveSpeed, acceleration * Time.deltaTime);
            _animator.SetBool("Walk", true);
            Vector3 newScale = transform.localScale;
            newScale.x = -Mathf.Abs(newScale.x); // Yüzü sola döndür
            transform.localScale = newScale;
        }
        else
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, 0, slowingDown);
            _animator.SetBool("Walk", false);
        }

        transform.Translate(_velocity * Time.deltaTime);
    }

    
    }
