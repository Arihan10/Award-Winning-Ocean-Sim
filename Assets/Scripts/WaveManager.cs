using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1f, length = 2f, speed = 1f, offset = 0f;
    public float bigAmplitude = 2.5f, bigLength = 7f, bigSpeed = 0.12f; 
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) {
            instance = this; 
        } else if (instance != this) {
            Debug.Log("Instance already exists, nuking object!");
            Destroy(this); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset += speed * Time.deltaTime;
        //GetComponent<MeshRenderer>().material.SetFloat("offsetVal", offset); 
        GetComponent<MeshRenderer>().material.SetFloat("offsetVal", Time.timeSinceLevelLoad); 
    }

    public float getWaveHeight (float _x, float _z) {
        return amplitude * Mathf.Sin(_x / length + offset) * Mathf.Sin(_z / length + offset) + (bigAmplitude * Mathf.Sin(_x / bigLength + offset) * Mathf.Sin(_z / 10f + offset/2)); 
        //return amplitude * Mathf.PerlinNoise(_x / length + offset, _z / length + offset); 
    }
}
