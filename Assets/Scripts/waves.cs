﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves : MonoBehaviour {
    public Transform cam;
    Material mat;
    public float extent = 750;
    // Start is called before the first frame update
    void Start() {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update() {
        float xPos = cam.position.x;
        float zPos = cam.position.z;
        xPos += extent;
        zPos += extent;
        xPos /= (extent * 2);
        zPos /= (extent * 2);
        float xCoord = Mathf.Lerp(-15, 0, xPos);
        float zCoord = Mathf.Lerp(-15, 0, zPos);
        mat.SetVector("waterCamPos", new Vector2(xCoord, zCoord));
    }
}