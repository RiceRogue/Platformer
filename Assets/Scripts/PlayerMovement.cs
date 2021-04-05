using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rgb;
    public Camera cam;
    
    // Set in Editor
    private float speed = 6.0f;
    private float jumpSpeed = 0.5f;
    


    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        cam = Camera.main;
        

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool jump = Input.GetKey(KeyCode.Space);



        //Code from Nimso Ny's tutorial on moving the player relative to the camera. https://www.youtube.com/watch?v=ORD7gsuLivE 
        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        
        camForward = camForward.normalized * z;
        camRight = camRight.normalized * x;
        //using transform position does not have as good of collisions, so I am using the movement from Rigidbody instead. 

        rgb.AddForce((camForward + camRight) * speed);


        //]

        //transform.rotation = cam.transform.rotation;
        


        //jumping function, can only jump when near or touching a car. 

        int platformLayer = LayerMask.GetMask("PlatformCar");

        bool RaycastTouch = Physics.Raycast(transform.position, Vector3.down, jumpSpeed, platformLayer);
        Debug.Log(RaycastTouch);
        if (jump && RaycastTouch)
        {

            rgb.AddForce(cam.transform.up * jumpSpeed, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Game");
        }



    }
   }
