using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", 
        VERTICAL = "Vertical";

    public static bool playerCreated;
    
    private float inputTol = 0.2f; // Input tolerance
    private float xInput, yInput;
    
    private bool isWalking;
    private Vector2 lastDirection;
    private Animator _animator;

    private Rigidbody2D _rigidbody;
    
    private void Awake(){
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerCreated = true;
    }

    void Update(){
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);
        isWalking = false;
        
        // Horizontal Movement
        if (Mathf.Abs(xInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(xInput * speed,
                0);
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }
        // Vertical movement
        if (Mathf.Abs(yInput) > inputTol){
            _rigidbody.velocity = new Vector2(0,
                yInput * speed);
            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }

    private void LateUpdate()
    {
        if (!isWalking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        
        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);
        _animator.SetFloat("LastHorizontal", lastDirection.x);
        _animator.SetFloat("LastVertical", lastDirection.y);
        _animator.SetBool("IsWalking", isWalking);
    }
}
