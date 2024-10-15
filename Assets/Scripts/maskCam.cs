using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskCam : MonoBehaviour
{
    public Transform _boat; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _boat.position + new Vector3(0, 10, 0); 
    }
}
