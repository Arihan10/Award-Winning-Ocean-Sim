using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Underwater_PlayerShoot : MonoBehaviour
{
    public float range = 30f;

    public Text scoreText;
    public GameObject player; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot(); 
        }
        if (Score.instance != null) {
            scoreText.text = Score.instance.score.ToString(); 
        }
    }

    private void Shoot() {
        RaycastHit hit; 
        Physics.Raycast(transform.position, transform.forward, out hit, range); 

        if (hit.transform.name != null) {
            if (hit.collider.tag == "Garbage") {
                player.GetComponent<AudioSource>().Play(); 
                if (Score.instance != null) {
                    ++Score.instance.score; 
                }
                Destroy(hit.collider.gameObject); 
            }
        }
    }
}
