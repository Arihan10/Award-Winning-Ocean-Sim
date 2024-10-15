using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Material[] materials;

    public float minSize = -0.5f, maxSize = 1.5f; 
    private float newSize; 
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        //newSize = Random.Range(-0.5f, 3f); 
        newSize = Random.Range(minSize, maxSize);
        transform.localScale += new Vector3(newSize, newSize, newSize); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
