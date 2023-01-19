using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunnerMovement : MonoBehaviour
{
    public float speed=7f;
    public float move;
    public float jumpHeight=10f;
    public bool isJumping;

    Vector2 movementVector;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 runnerVelocity = new Vector2(movementVector.x*speed, rb.velocity.y);
        rb.velocity=runnerVelocity; 
    }
    

    private void  OnMove(InputValue value){
        movementVector=value.Get<Vector2>();
        Debug.Log(movementVector);
    }
    private void OnJump(InputValue value){
        if(value.isPressed && isJumping==false){
            rb.velocity+=new Vector2(0f, jumpHeight);
        }
    }
    private void OnCollisionEnter2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D item)
    {
        if (item.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
