using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public GameObject trashBig, special, special2; 
    public int underwaterThreshold = 30; 
    public GameObject[] trashes;

    bool shown = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; ++i) {
            Instantiate(trashes[Random.Range(0,trashes.Length)], new Vector3(Random.Range(-746f, 746f), Random.Range(-15f, 2f), Random.Range(-746f, 746f)), Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.instance.score - Score.instance.lastUnderwaterEntryPoint >= underwaterThreshold) {
            if (!shown) {
                StartCoroutine(specialReady());
                shown = true; 
            }
            if (Input.GetKey("x")) {
                Score.instance.lastUnderwaterEntryPoint = Score.instance.score;
                SceneManager.LoadScene("Underwater");
            }
        }
    }

    IEnumerator specialReady() {
        special.SetActive(true); 
        special2.SetActive(true); 
        yield return new WaitForSeconds(3f);
        special.SetActive(false); 
    }
}
