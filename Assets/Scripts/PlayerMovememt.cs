using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovememt : MonoBehaviour
{
    public float maxSpeed;
    public float maxRotation;
    private Rigidbody rb;
    public float jumpForce = 7f;
    public Transform jumpCheckPos;
    private bool isJump = false;


    public Transform cam;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump")){
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calculate the target angle based on camera direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Smooth rotation towards the target angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref maxRotation, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the player in the direction they are facing
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 newVelocity = moveDirection * maxSpeed;
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity;
        }
        else
        {
            // Maintain vertical velocity when not moving
            Vector3 newVelocity = rb.velocity;
            newVelocity.x = 0;
            newVelocity.z = 0;
            rb.velocity = newVelocity;
        }



        // Vector3 newVelocity = transform.forward * vertical * maxSpeed;
        // newVelocity.y = rb.velocity.y;
        // rb.velocity = newVelocity;

        if(isJump && (Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length > 0))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJump = false;
        }

        // transform.Rotate(Vector3.up, horizontal * maxRotation * Time.fixedDeltaTime, 0f);

        // Debug.Log("Print");
    }
}
