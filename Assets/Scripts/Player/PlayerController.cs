using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Joystick joystick;

    private JoystickButtonController _joystickButtonController;

    private bool isJumping;

    void Start()
    {
        _joystickButtonController = FindObjectOfType<JoystickButtonController>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
#if UNITY_EDITOR
        KeyboardController();
#else        
        JoystickController();
#endif
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

    void JoystickController()
    {
        float movementInput = joystick.Horizontal;
        
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

        if (_joystickButtonController.isPressed == true && isJumping == false)
        {
            isJumping = true;
            StartJumping();
        }
        
        if (_joystickButtonController.isPressed == false && isJumping ==true)
        {
            isJumping = false;
            StopJumping();
        }
    }

    void StartJumping()
    {
        if (jumpCount < jumpLimit)
        {
            FindObjectOfType<SoundController>().JumpSound();
            rb.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
            _animator.SetBool("Jump",true);
            FindObjectOfType<SliderController>().SliderValue(jumpLimit,jumpCount);
        }
    }

    void StopJumping()
    {
        _animator.SetBool("Jump",false);
        jumpCount++;
        FindObjectOfType<SliderController>().SliderValue(jumpLimit,jumpCount);
    }

    public void ResetJumpCount()
    {
        jumpCount = 0;
        FindObjectOfType<SliderController>().SliderValue(jumpLimit,jumpCount);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            FindObjectOfType<GameController>().FinishGame();
        }
    }


    public void PlayerGameOver()
    {
        Destroy(gameObject);
    }
}
