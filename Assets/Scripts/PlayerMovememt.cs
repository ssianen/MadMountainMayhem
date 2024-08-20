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

        Vector3 newVelocity = transform.forward * vertical * maxSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;

        if(isJump && (Physics.OverlapSphere(jumpCheckPos.position, 0.05f, LayerMask.GetMask("Ground")).Length > 0))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
            isJump = false;
        }

        transform.Rotate(Vector3.up, horizontal * maxRotation * Time.fixedDeltaTime, 0f);

        // Debug.Log("Print");
    }
}
