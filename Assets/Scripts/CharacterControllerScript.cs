using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller;

    // Set in Editor
    [SerializeField] float speed = 6.0f;
    [SerializeField] float jumpSpeed = 8.0f;
    [SerializeField] float gravity = 20.0f;


    // Others
    private Vector3 moveDirection = Vector3.zero;

    // Controls
    private float xMove;
    private float yMove;
    private bool jump;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(xMove, 0.0f, yMove);
            moveDirection *= speed;


            // Face in dir of move
            if (moveDirection.magnitude > float.Epsilon)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection * Time.fixedDeltaTime);
            }


            if (jump)
            {
                moveDirection.y = jumpSpeed;
            }

        }

        // Apply gravity
        moveDirection.y -= gravity * Time.fixedDeltaTime;

        controller.Move(moveDirection * Time.fixedDeltaTime);
    }


    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");
    }
}


