using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        
        bool isSprinting = FindObjectOfType<PlayerMovememt>().GetSprint();
        bool isJumping = FindObjectOfType<PlayerMovememt>().GetJump();

        if (isJumping) {
            animatorVal.SetBool("Jump", true);
        } else {
            animatorVal.SetBool("Jump", false);
        }
        if(FindObjectOfType<PlayerMovememt>().GetVelocity().x == 0 && FindObjectOfType<PlayerMovememt>().GetVelocity().z == 0){
            animatorVal.SetFloat("Speed", 0);
        }
        else if (isSprinting){
            animatorVal.SetFloat("Speed", 3);
            
        }  else if (!isJumping){
            animatorVal.SetFloat("Speed", 1);
            
        }

        // if(newVelocity == Vector3.zero){
        //     animatorVal.SetFloat("Speed", 0);
        // }
        // else if (Input.GetKey(KeyCode.LeftShift)){
        //     animatorVal.SetFloat("Speed", 3);
        // } else {
        //     animatorVal.SetFloat("Speed", 1);
        // }
    }
}
