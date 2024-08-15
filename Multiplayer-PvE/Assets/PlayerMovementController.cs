using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprit = 12f;
    public float jumpHight = 2f;
    public float gravity = -30;
    [Space]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            controller.Move(move * speed * sprit * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
