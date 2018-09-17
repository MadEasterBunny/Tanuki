using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //private float slowDown = 0.95f;

    //Wall Jump
    private Quaternion myRotation;
    private bool hasJumped;

    //Animations
    private Animator animator;

    //Collectables
    public Text goodsText;
    private int stolenGoods;

    //Jump Sound Effect
    private AudioSource audioSouce;
    public AudioClip jumpEffect;

    void Start ()
    {
        myController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        myRotation = transform.rotation;
        audioSouce = GetComponent<AudioSource>();
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
                audioSouce.PlayOneShot(jumpEffect, 0.2f);
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

    public void ForwardMovement()
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
        animator.SetFloat("isWalking", myController.velocity.z);
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
                audioSouce.PlayOneShot(jumpEffect, 0.2f);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "StolenGoods")
        {
            stolenGoods++;
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
            Destroy(other.gameObject);
        }
    }
}
