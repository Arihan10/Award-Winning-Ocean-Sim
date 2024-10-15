using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater_PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 30f, speedH, speedV, jumpSpeed = 15f;
    private float deltaTimeOffset = 50f;
    [HideInInspector]
    public float yaw = 0f, pitch = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) {
            rb.AddForce(transform.forward * movementSpeed * Time.deltaTime * deltaTimeOffset); 
        } else if (Input.GetKey("s")) {
            rb.AddForce(transform.forward * -movementSpeed * Time.deltaTime * deltaTimeOffset); 
        }

        if (Input.GetKey("d")) {
            rb.AddForce(transform.right * movementSpeed * Time.deltaTime * deltaTimeOffset);
        } else if (Input.GetKey("a")) {
            rb.AddForce(transform.right * -movementSpeed * Time.deltaTime * deltaTimeOffset);
        }

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(new Vector3(0f, 1f * jumpSpeed * Time.deltaTime * deltaTimeOffset, 0f)); 
        }
        //pitch += speedV * Input.GetAxis("Mouse Y");
        //pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f); 
    }
}
