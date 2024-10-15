using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed, rotationSpeed, rotationSlowdown;

    private float deltaTimeOffset = 50f;

    Vector3 rotation;

    public float rotating = 0.1f;
    bool rotatingRN = false;

    public Material[] materials;
    public GameObject[] bodyOars; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = Score.instance.boatStats[Score.instance.boatNo, 0]; 
        rotationSpeed = Score.instance.boatStats[Score.instance.boatNo, 1];
        transform.localScale = new Vector3(transform.localScale.x * Score.instance.boatStats[Score.instance.boatNo, 4], transform.localScale.y * Score.instance.boatStats[Score.instance.boatNo, 4], transform.localScale.z * Score.instance.boatStats[Score.instance.boatNo, 4]); 

        for (int i = 0; i < bodyOars.Length; ++i) {
            bodyOars[i].GetComponent<MeshRenderer>().material = materials[Score.instance.boatNo]; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if (Input.GetKey("a")) {
            rb.AddForce(transform.right * -speed * Time.deltaTime * deltaTimeOffset); 
        } else if (Input.GetKey("d")) {
            rb.AddForce(transform.right * speed * Time.deltaTime * deltaTimeOffset); 
        }
        */
        rotation = transform.eulerAngles;
        //rotating = movementSpeed; 

        if (Input.GetKey("a")) {
            rb.AddForce(transform.forward * movementSpeed * Time.deltaTime * deltaTimeOffset); 
            rotation.y -= rotationSpeed;
            //rotating = movementSpeed/rotationSlowdown;
            transform.eulerAngles = rotation;
            GetComponent<Animator>().SetBool("LeftPaddle", true);
            GetComponent<Animator>().SetBool("RightPaddle", false);
            rotatingRN = true; 
            //transform.position += transform.forward * rotating * Time.deltaTime * deltaTimeOffset; 
        } else if (Input.GetKey("d")) {
            rb.AddForce(transform.forward * movementSpeed * Time.deltaTime * deltaTimeOffset); 
            rotation.y += rotationSpeed;
            //rotating = movementSpeed/rotationSlowdown;
            transform.eulerAngles = rotation;
            GetComponent<Animator>().SetBool("RightPaddle", true);
            GetComponent<Animator>().SetBool("LeftPaddle", false);
            rotatingRN = true; 
            //transform.position += transform.forward * rotating * Time.deltaTime * deltaTimeOffset; 
        } else if (Input.GetKey("w")) {
            //rb.AddForce(transform.forward * (rotating) * Time.deltaTime * deltaTimeOffset); 
            rb.AddForce(transform.forward * movementSpeed * Time.deltaTime * deltaTimeOffset);
            //transform.position += transform.forward * rotating * Time.deltaTime * deltaTimeOffset; 
            GetComponent<Animator>().SetBool("RightPaddle", true); 
            GetComponent<Animator>().SetBool("LeftPaddle", true); 
        } else if (Input.GetKey("s")) {
            //rb.AddForce(transform.forward * -(rotating) * Time.deltaTime * deltaTimeOffset); 
            rb.AddForce(transform.forward * -movementSpeed * Time.deltaTime * deltaTimeOffset);
            //transform.position -= transform.forward * rotating * Time.deltaTime * deltaTimeOffset; 
            GetComponent<Animator>().SetBool("RightPaddle", true); 
            GetComponent<Animator>().SetBool("LeftPaddle", true); 
        } else {
            GetComponent<Animator>().SetBool("RightPaddle", false); 
            GetComponent<Animator>().SetBool("LeftPaddle", false); 
        }

        /* 
        if (rotatingRN && !Input.GetKey("a") && !Input.GetKey("d")) { 
            GetComponent<Animator>().SetBool("RightPaddle", false); 
            GetComponent<Animator>().SetBool("LeftPaddle", false);
            //GetComponent<Animator>().Play("Idle"); 
            rotatingRN = false; 
        }
        */
    }
}
