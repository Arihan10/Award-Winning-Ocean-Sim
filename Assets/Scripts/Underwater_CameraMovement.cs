using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater_CameraMovement : MonoBehaviour
{
    private float pitch = 0f;
    public float speedV;
    public Underwater_PlayerMovement _player; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ///* 
        //yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(-pitch, _player.yaw, 0.0f); 
        //*/
    }
}
