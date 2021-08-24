using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float waitTime = 2f;
    [HideInInspector] 
    public float timePassed = 0f;
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;
        float horizontalSpeed = Mathf.Abs(horizontalMove);
        animator.SetFloat("Speed", horizontalSpeed);

        if(horizontalSpeed >= 2.5 && timePassed >= waitTime) {
            FindObjectOfType<AudioManager>().Play("PlayerWalk");
            timePassed = 0f;
        } else {
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
            // timePassed = 0f;
        }
    

        if(CrossPlatformInputManager.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        } else {
            FindObjectOfType<AudioManager>().Stop("PlayerJump");
        }
        if(Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if(Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() 
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
