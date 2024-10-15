using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BoatCollision : MonoBehaviour
{

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.instance.score.ToString(); 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Garbage") {
            GetComponent<AudioSource>().Play(); 
            StartCoroutine(ridOfGarbage(collision.gameObject));
            ++Score.instance.score;
        }
    }

    IEnumerator ridOfGarbage(GameObject _object) {
        yield return new WaitForSeconds(0.1f);
        Destroy(_object); 
    }
}
