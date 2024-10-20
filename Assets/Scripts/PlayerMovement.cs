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
    public float shroomForce;
    public Transform cam;
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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

        // Finds player size and sets speeds
        int playerSize = AssignSize();

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

        float jumpOverlap;
        if (playerSize >= 2) {
            // If player is not small, they can jump on the mushroom
            jumpOverlap = Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground", "ShroomBounce")).Length;
        } else {
            // If the player is small, they cannot jump on the mushroom
            jumpOverlap = Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length;
        }

        if(isJump && jumpOverlap > 0)
        {
            // Lauch player by jump amount
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJump = false;
        }

        // If player is small and touching shroom
        if(playerSize == 1 && (Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("ShroomBounce")).Length > 0))
        {
            // Play bounce sound effect
            audioManager.PlaySFX(audioManager.bounce);

            // Lauch the player upwards
            rb.AddForce(new Vector3(0f, shroomForce, 0f), ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Sets player speeds according to player size found in ResizePlayer script
    /// </summary>
    /// <returns>
    /// Size of the player, with 1 for small, 2 for regular, and 3 for large
    /// </returns>
    private int AssignSize() {
        // Calls GetSize() from resizePlayer script to get the current player size
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
        return size;
    }
    
    public bool GetSprint() {
        return isSprint;
    }

    /// <summary>
    /// Indicates if player is in the air or not
    /// </summary>
    /// <returns>
    /// True if player is in the air, false otherwise
    /// </returns>
    public bool GetJump() {
        return Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground", "ShroomBounce")).Length <= 0;
    }

    public Vector3 GetVelocity() {
        return rb.velocity;
    }
}
