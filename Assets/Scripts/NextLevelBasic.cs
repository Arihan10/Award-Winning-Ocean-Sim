using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NextLevelBasic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextLevel() {
        Score.instance.gameTimeFunction();
        Score.instance.score = 0; 
        SceneManager.LoadScene("GameLevel"); 
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if (Input.anyKey) {
            Score.instance.gameTimeFunction(); 
            SceneManager.LoadScene("GameLevel"); 
        }
        */
    }
}
