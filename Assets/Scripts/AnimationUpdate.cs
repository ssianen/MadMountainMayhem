using System.Collections;
using System.Collections.Generic;
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
        if(newVelocity == Vector3.zero){
            animatorVal.SetFloat("Speed", 0);
        }
        else {
            animatorVal.SetFloat("Speed", 1);
        }
    }
}
