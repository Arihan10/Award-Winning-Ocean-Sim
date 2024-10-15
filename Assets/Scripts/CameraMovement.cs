using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target; //the target object
    public float speed = 10.0f; //a speed modifier
    private float yaw; 
    private Vector3 point; //the coord to the point where the camera looks at
    public Camera mainCam; 

    void Start() { //Set up things on the start method
    }

    void Update() { //makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 

        /* 
        point = target.transform.position; //get target's coords
        //transform.position = new Vector3(point.x + 0.08729039f, transform.position.y, point.z - 10.4971f);
        transform.LookAt(point); //makes the camera look to it

        yaw = Input.GetAxis("Mouse X") * speed; 
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * yaw); 
        */

        if (Input.GetButton("Fire1")) {
            GetComponent<Camera>().enabled = true;
            mainCam.enabled = false; 
        } else if (Input.GetButtonDown("Fire2")) {
            GetComponent<Camera>().enabled = false;
            mainCam.enabled = true; 
        }

        yaw = Input.GetAxis("Mouse X") * speed;
        transform.Rotate(0f, yaw, 0f); 
    }
}
