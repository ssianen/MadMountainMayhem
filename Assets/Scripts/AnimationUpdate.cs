using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AnimationUpdate : MonoBehaviour
{
    private Animator animatorVal;
    // Start is called before the first frame update
    void Start()
    {
        animatorVal = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movement direction
        Vector3 moveDirectionVert = transform.forward * vertical;
        Vector3 newVelocity = moveDirectionVert * 2;
        // Animations
        
        bool isSprinting = FindObjectOfType<PlayerMovement>().GetSprint();
        bool isJumping = FindObjectOfType<PlayerMovement>().GetJump();

        if (isJumping) {
            animatorVal.SetBool("Jump", true);
        } else {
            animatorVal.SetBool("Jump", false);
        }

        if (horizontal < 0) {
            animatorVal.SetBool("StrafeLeft", true);
            animatorVal.SetBool("StrafeRight", false);
        } else if (horizontal > 0) {
            animatorVal.SetBool("StrafeLeft", false);
            animatorVal.SetBool("StrafeRight", true);
        } else {
            animatorVal.SetBool("StrafeLeft", false);
            animatorVal.SetBool("StrafeRight", false);
        }

        if (vertical == 0) {
            animatorVal.SetBool("Forward", false);
        } else {
            animatorVal.SetBool("Forward", true);
        }

        if(FindObjectOfType<PlayerMovement>().GetVelocity().x == 0 && FindObjectOfType<PlayerMovement>().GetVelocity().z == 0){
            animatorVal.SetFloat("Speed", 0);
        }
        else if (isSprinting){
            animatorVal.SetFloat("Speed", 3);
            
        }  else if (!isJumping){
            animatorVal.SetFloat("Speed", 1);
            
        }
    }
}
