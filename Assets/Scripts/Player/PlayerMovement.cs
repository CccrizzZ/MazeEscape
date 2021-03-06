using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;




public class PlayerMovement : MonoBehaviour
{
    // parameters
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpForce;    
    public bool isRunning;
    public bool isJumping;
    public bool isGrounded;
    public bool canMove;

    // references
    Rigidbody rbRef;
    Animator animController;
    PlayerCamera pcamRef;

    // movement var
    public Vector2 InputVector;
    Vector3 MoveDirection;
    float CurrentSpeed;


    
    void Start()
    {
        canMove = true;
        isGrounded = true;
        rbRef = GetComponent<Rigidbody>();
        animController = GetComponent<Animator>();
        pcamRef = GetComponent<PlayerCamera>();
    }

    void Update()
    {
        if(canMove)
        {

            // determine player direction
            MoveDirection = transform.forward * InputVector.y + transform.right * InputVector.x;

            // apply velocity if in air
            if(!isGrounded)
            {
                rbRef.velocity += MoveDirection / 10;
            }
    
    
            // if is jumping dont move
            if(isJumping) return;

            // if no input dont move
            if(InputVector.magnitude <= 0) return;


            // determine walking or running 
            if (isRunning)
            {
                CurrentSpeed = RunSpeed;
            }
            else
            {
                CurrentSpeed = WalkSpeed;
            }




            // make movement vector
            Vector3 movement = MoveDirection * (CurrentSpeed * Time.deltaTime);

            // apply movement
            transform.position += movement;


            // rbRef.MovePosition(transform.position + movement * 5);

            // if(InputVector != Vector2.zero)
            // {
            //     float targetAngle = Mathf.Atan2(InputVector.x, InputVector.y) * Mathf.Rad2Deg + pcamRef.CamTransform.eulerAngles.y;
            //     Quaternion rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
            //     transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
            // }


        }
    }
    
    public void OnMove(InputValue value)
    {
        if (Time.timeScale == 1 && canMove)
        {
            
            // get input vector from input value
            InputVector = value.Get<Vector2>();

            if (InputVector.y > 0)
            {
                animController.SetFloat("YMovement", InputVector.y * 0.25f);
            }
            else
            {
                animController.SetFloat("YMovement", InputVector.y * 0.5f);
            }

            animController.SetFloat("XMovement", InputVector.x * 0.5f);


            // print(MoveDirection);
        }


    }


    public void OnRun(InputValue input)
    {
        if (input.Get().ToString() == "1" && canMove)
        {
            isRunning = true;
            if(InputVector.y > 0)
            {
                animController.SetFloat("YMovement", 0.5f);
            }
        }
        else
        {
            isRunning = false;
            if(InputVector.y > 0)
            {
                animController.SetFloat("YMovement", 0.25f);
            }
            else if(InputVector.y < 0)
            {
                animController.SetFloat("YMovement", -0.5f);

            }
            else
            {
                animController.SetFloat("YMovement", 0.0f);
                
            }
        }
    }


    public void OnJump(InputValue input)
    {
        if(!isJumping && isGrounded && Time.timeScale == 1 && GetComponent<PlayerStatus>().Health > 0 && canMove)
        {
            // // reset velocity
            // rbRef.velocity = Vector3.zero;

            // set jump bool
            isJumping = input.isPressed;

            // add force to rigidbody
            rbRef.AddForce(4 * (transform.up + MoveDirection ) * (JumpForce + CurrentSpeed) / 2 , ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            // print("Grounded");
            isGrounded = true;
            isJumping = false;
        }
    }

    void DisableMovement()
    {
        canMove = false;
    }

    void EnableMovement()
    {
        canMove = true;
    }
}
