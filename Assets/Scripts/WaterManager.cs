using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; 

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    Material mat;
    int ability = 0;

    public float speedupFactor = 2f, abilityAvailableTime = 30f;
    public int showGarbageTime = 15;
    public GameObject boat, text, secondary, secondary2, postProcessing; 

    bool used = true; 

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mat = GetComponent<MeshRenderer>().material;
        StartCoroutine(nextUse()); 
    }

    IEnumerator nextUse() {
        yield return new WaitForSeconds(abilityAvailableTime); 
        secondary.SetActive(true);
        secondary2.SetActive(true); 
        secondary.GetComponent<DissapearAfter>().startDisspearing(); 
        used = false; 
    }

    IEnumerator showAllGarbage() {
        //ability = 1; 
        used = true;
        ChromaticAberration chromaticAberration;
        Vignette vignette; 
        postProcessing.GetComponent<Volume>().profile.TryGet(out chromaticAberration);
        postProcessing.GetComponent<Volume>().profile.TryGet(out vignette);
        chromaticAberration.intensity.value = 0.276f;
        vignette.intensity.value = 0.409f; 
        secondary2.SetActive(false); 
        mat.SetFloat("maxDepthVal", 1000);
        boat.GetComponent<BoatMovement>().movementSpeed *= speedupFactor;
        text.SetActive(true); 
        Debug.Log("started");
        for (int i = 0; i < showGarbageTime; ++i) {
            text.GetComponent<Text>().text = (showGarbageTime - i).ToString(); 
            yield return new WaitForSeconds(1f); 
        }
        mat.SetFloat("maxDepthVal", 65f);
        boat.GetComponent<BoatMovement>().movementSpeed /= speedupFactor;
        text.SetActive(false);
        chromaticAberration.intensity.value = 0;
        vignette.intensity.value = 0f;
        Debug.Log("ended");
        //ability = 0; 
        StartCoroutine(nextUse()); 
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        Vector3[] vertices = meshFilter.mesh.vertices; 
        for (int i = 0; i < vertices.Length; ++i) {
            vertices[i].y = WaveManager.instance.getWaveHeight(transform.position.x + vertices[i].x, transform.position.z + vertices[i].z); 
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals(); 
        */
        if (!used) {
            if (Input.GetButton("Fire3")) {
                StartCoroutine(showAllGarbage());
            }
        }
    }
}
