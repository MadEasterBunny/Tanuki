using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerPlayerController : MonoBehaviour
{
    private CharacterController myController;
    
    public float jumpForce;
    public float gravityModifier;
    public float runSpeed;
    public float lerpTime;

    private float gravityForce = 9.8f;
    private float ySpeed;
    private float hangTimer;
    private float hangTime = 0.5f;
    private float forwardSpeed;

    //Wall Jump
    private Quaternion myRotation;
    private bool hasJumped;

    void Start ()
    {
        myController = GetComponent<CharacterController>();
        myRotation = transform.rotation;
	}
	
	
	void FixedUpdate ()
    {
        Gravity();
        Jump();
        ForwardMovement();
        ApplySpeed();
	}

    private void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            hasJumped = false;
        }
    }

    void Gravity()
    {
        ySpeed = myController.velocity.y;
        ySpeed -= gravityForce * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButton("Fire1"))
        {
            if (myController.isGrounded && !hasJumped)
            {
                hasJumped = true;
                hangTimer = hangTime;
                ySpeed = jumpForce;
            }
            else
            {
                if(hangTimer > 0)
                {
                    hangTimer -= Time.deltaTime;
                    ySpeed += gravityModifier * hangTimer * Time.deltaTime;
                }
            }
        }
    }

    void ForwardMovement()
    {
        if (myController.isGrounded)
        {
            if (forwardSpeed <= runSpeed - 0.1f || forwardSpeed >= runSpeed + 0.1f)
            {
                forwardSpeed = Mathf.Lerp(forwardSpeed, runSpeed, lerpTime);
            }
            else
            {
                forwardSpeed = runSpeed;
            }
        }
    }

    void ApplySpeed()
    {
        myController.Move(transform.forward * forwardSpeed * Time.deltaTime);
        myController.Move(new Vector3(0, ySpeed, 0) * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GroundLanding();
        WallJump(hit);
    }

    void WallJump(ControllerColliderHit hitSent)
    {
        if(!myController.isGrounded && hitSent.normal.y < 0.1f && hitSent.normal.y > -0.1f)
        {
            if(Input.GetButton("Fire1") && !hasJumped)
            {
                hasJumped = true;
                //Makes character change direction of hit wall
                transform.forward = hitSent.normal;
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

                //moves backwards
                forwardSpeed = runSpeed;

                //makes character jump up higher during wall jump
                hangTimer = hangTime;
                ySpeed = jumpForce;
            }
        }
    }

    void GroundLanding()
    {
        if(myRotation != transform.rotation && myController.isGrounded)
        {
            transform.rotation = myRotation;
        }
    }
}
