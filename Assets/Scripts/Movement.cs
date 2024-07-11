using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 0.43f;

    Vector3 velocity;
    bool isGrounded;
    bool isGrounded2;
    float speedMul = 1f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float distanceToGround = 0.2f;
    [SerializeField] private LayerMask environmentMask;
    [SerializeField] private LayerMask pickMask;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, distanceToGround, environmentMask);
        isGrounded2 = Physics.CheckSphere(groundCheck.position, distanceToGround, pickMask);
        if ((isGrounded /*|| isGrounded2*/) && velocity.y < 0){
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && (isGrounded /*|| isGrounded2*/)){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKey(KeyCode.LeftShift)){
            speedMul = 1.5f;
        }
        if (!Input.GetKey(KeyCode.LeftShift)){
            speedMul = 1f;
        }
        Movemt(x, z, speedMul);

    }

    void Movemt(float x, float z, float speedMul){
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * speed * Time.deltaTime * speedMul);
        controller.Move(velocity * Time.deltaTime);
    }
}