using System.Collections;
using System.Collections.Generic;
using TMPro;

// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float smallSizedSpeedMult = 0.5f;
    public float largeSizedSpeedMult = 2.0f;
    public float regularSizedSpeed = 6f;
    public float maxRotation;
    private Rigidbody rb;
    public float jumpForce;
    public float smallSizedJumpMult = 0.75f;
    public float largeSizedJumpMult = 2.0f;
    public float regularSizedJump = 7f;
    public Transform jumpCheckPos;
    private bool isJump = false;
    private bool isSprint = false;
    public float sprintMult;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // called every frame
    private void Update()
    {   
        // If jump is pressed
        if(Input.GetButtonDown("Jump")){
            isJump = true;
        }
        // if shift is down
        if (Input.GetKey(KeyCode.LeftShift)){
            isSprint = true;
            // Debug.Log("sprinting");
        } else {
            isSprint = false;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0; // Keep movement on the horizontal plane
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        AssignSize();

        // Movement direction
        Vector3 moveDirection = camForward * vertical + camRight * horizontal;
        moveDirection.Normalize();

        // Sets player rotation to follow camera when moving forward
        if (vertical != 0)
        {
            // Calculate the target angle based on camera direction and vertical input
            float targetAngle = Mathf.Atan2(camForward.x, camForward.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref maxRotation, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // sets player rotation
        }
        
        // sets player rotation so strafing has player moving forward
        if (horizontal != 0)
        {
            // Calculate the target angle based on camera direction and vertical input
            float targetAngle = Mathf.Atan2(camForward.x, camForward.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref maxRotation, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        // Calculate new velocity for movement (forward/backward or strafing)
        Vector3 newVelocity = moveDirection * maxSpeed;
        if (isSprint) {
            newVelocity *= sprintMult;
        }
        newVelocity.y = rb.velocity.y; // Preserve vertical velocity for jumping/falling
        rb.velocity = newVelocity;

        if(isJump && (Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length > 0))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJump = false;
        }

    }

    private void AssignSize() {
        int size = FindObjectOfType<ResizePlayer>().GetSize();
        if (size == 1) {
            maxSpeed = smallSizedSpeedMult * regularSizedSpeed;
            jumpForce = smallSizedJumpMult * regularSizedJump;
        } else if (size == 2) {
            maxSpeed = regularSizedSpeed;
            jumpForce = regularSizedJump;
        } else if (size == 3) {
            maxSpeed = largeSizedSpeedMult * regularSizedSpeed;
            jumpForce = largeSizedJumpMult * regularSizedJump;
        } else {
            Debug.Log("Error: Size variables assigned incorrectly");
        }
    }

    public bool GetSprint() {
        return isSprint;
    }

    public bool GetJump() {
        return Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length <= 0;
    }

    public Vector3 GetVelocity() {
        return rb.velocity;
    }
}
