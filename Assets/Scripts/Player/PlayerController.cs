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
    
    [SerializeField] private float jumpPower;

    [SerializeField] int jumpLimit = 3;

    private int jumpCount;

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
        if (Input.GetKeyDown("space"))
        {
            StartJumping();
        }

        if (Input.GetKeyUp("space"))
        {
            StopJumping();
        }
    }

    void StartJumping()
    {
        if (jumpCount < jumpLimit)
        {
            rb.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
            _animator.SetBool("Jump",true);
        }
    }

    void StopJumping()
    {
        _animator.SetBool("Jump",false);
        jumpCount++;
    }

    public void ResetJumpCount()
    {
        jumpCount = 0;
    }

    
    
}
