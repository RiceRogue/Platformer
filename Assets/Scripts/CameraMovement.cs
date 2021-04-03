using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;
    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        //Taken from https://gamedevacademy.org/unity-3d-first-and-third-person-view-tutorial/#Section_2_Third_Person_Perspective
        //This essentially moves the camera's rotation and position to remain around a good range for third person perspective. 
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;


        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);

        //Adjusts how close the camera is, by multiplying the distance by a constant. 
        transform.position = target.transform.position - (transform.forward * targetDistance * 0.55f) + (transform.up * 2f);

    }
}
