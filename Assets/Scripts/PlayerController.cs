using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", 
        VERTICAL = "Vertical";
    
    private float inputTol = 0.2f; // Input tolerance
    private float xInput, yInput;
    
    private bool isWalking;
    private Vector2 lastDirection;
    private Animator _animator;
    
    private void Awake(){
        _animator = GetComponent<Animator>();
    }
    
    void Update(){
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);
        isWalking = false;
        
        if (Mathf.Abs(xInput) > inputTol){
            Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 
                0, 0);
            transform.Translate(translation);
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }
        
        if (Mathf.Abs(yInput) > inputTol){
            Vector3 translation = new Vector3( 0, 
                yInput * speed * Time.deltaTime, 0);
            transform.Translate(translation);
            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }
}
