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
        Vector2 scale = transform.localScale;
        if (movementInput > 0)
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * moveSpeed, acceleration * Time.deltaTime);
            _animator.SetBool("Walk",true);
            scale.x = 1;
        }
        else if (movementInput <0)
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, movementInput * moveSpeed, acceleration * Time.deltaTime);
            _animator.SetBool("Walk",true);
            scale.x = -1;
        }
        else
        {
            _velocity.x = Mathf.MoveTowards(_velocity.x, 0, slowingDown);
            _animator.SetBool("Walk",false);
        }
        gameObject.transform.Translate(_velocity* Time.deltaTime);
    }
}
