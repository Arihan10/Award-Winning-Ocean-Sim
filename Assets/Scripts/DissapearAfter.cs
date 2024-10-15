using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearAfter : MonoBehaviour
{
    public float seconds; 
    
    // Start is called before the first frame update
    void Awake()
    {
        //StartCoroutine(dissappearAfter()); 
    }

    public void startDisspearing() {
        StartCoroutine(dissappearAfter()); 
    }

    IEnumerator dissappearAfter() {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false); 
    }
}
