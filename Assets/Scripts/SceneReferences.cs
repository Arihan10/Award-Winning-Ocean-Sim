using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SceneReferences : MonoBehaviour
{
    public GameObject[] boatSelections;
    public Text latestScore, highScore; 
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll(); 
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        latestScore.text = Score.instance.score.ToString();
        if (Score.instance.score > PlayerPrefs.GetInt("highscore", 0)) {
            PlayerPrefs.SetInt("highscore", Score.instance.score);
        }
        GameObject.Find("highScore").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore", 0).ToString(); 
    }

    public void switchBoat(string dir) {
        Score.instance.switchBoat(dir); 
    }

    public void buyBoat(int _num) {
        Score.instance.buyBoat(_num); 
    }

    public void selectBoat(int _num) {
        Score.instance.selectBoat(_num); 
    }
}
