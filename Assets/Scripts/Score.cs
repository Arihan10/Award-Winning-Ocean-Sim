using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MultiDimensionalInt {
  public float[] intArray;
}

public class Score : MonoBehaviour
{
    public static Score instance; 
    
    //[HideInInspector]
    public int score = 0, lastUnderwaterEntryPoint = 0, gameLength = 120, boats = 4, boatNo; 
    private int boatDisplay = 0; 
    //public float[,] boatStats = new float[4,4]; 
    //public MultiDimensionalInt[] boatStats; 
    //movementSpeed, rotationSpeed, waterDrag, waterAngularDrag, scale
    public float[,] boatStats = new float[4, 5] { { 13f, 0.3f, 3f, 2f, 1f }, { 4f, 0.8f, 0.3f, 0.2f, 0.7f }, { 4f, 0.5f, 0.3f, 0.3f, 1.2f }, { 4f, 0.6f, 0.2f, 0.2f, 0.7f } };

    public int[] prices = new int[] { 0, 100, 150, 300 }; 

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Debug.Log("Instance already exists, nuking object!");
            Destroy(this);
        }

        DontDestroyOnLoad(this.gameObject);

        //StartCoroutine(gameTime()); 

        GameObject.Find("scoreText").GetComponent<Text>().text = PlayerPrefs.GetInt("score", 0).ToString(); 

        RectTransform _speedBar = GameObject.Find("speedBar").GetComponent<RectTransform>(); 
        _speedBar.localScale = new Vector3((float)boatStats[boatDisplay, 0] / 15f, _speedBar.localScale.y, _speedBar.localScale.x); 
        RectTransform _rotationBar = GameObject.Find("rotationBar").GetComponent<RectTransform>(); 
        _rotationBar.localScale = new Vector3((float)boatStats[boatDisplay, 1] / 1.5f, _rotationBar.localScale.y, _rotationBar.localScale.x); 
        RectTransform _dragBar = GameObject.Find("dragBar").GetComponent<RectTransform>(); 
        _dragBar.localScale = new Vector3((float)boatStats[boatDisplay, 2] / 3f, _dragBar.localScale.y, _dragBar.localScale.x); 
        RectTransform _angularBar = GameObject.Find("angularBar").GetComponent<RectTransform>(); 
        _angularBar.localScale = new Vector3((float)boatStats[boatDisplay, 3] / 3f, _angularBar.localScale.y, _angularBar.localScale.x); 
        RectTransform _sizeBar = GameObject.Find("sizeBar").GetComponent<RectTransform>(); 
        _sizeBar.localScale = new Vector3((float)boatStats[boatDisplay, 4] / 1.6f, _sizeBar.localScale.y, _sizeBar.localScale.x); 
    }

    IEnumerator gameTime() {
        yield return new WaitForSeconds(2f); 
        for (int i = 0; i < gameLength; ++i) {
            //GameObject.Find("Timer").GetComponent<Text>().text = (120-(i + 1)).ToString(); 
            while (SceneManager.GetActiveScene().name != "GameLevel") {
                yield return new WaitForSeconds(0.5f); 
            }
            GameObject.Find("Timer").GetComponent<Text>().text = (gameLength-i)/60+":"+(gameLength-i)%60; 
            yield return new WaitForSeconds(1f); 
        }
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + score); 
        SceneManager.LoadScene(0); 
    }

    public void gameTimeFunction() {
        StartCoroutine(gameTime()); 
    }

    public void switchBoat(string dir) {
        if (dir == "left") {
            if (boatDisplay - 1 < 0) return; 
            --boatDisplay; 
        } else {
            if (boatDisplay + 1 == boats) return; 
            ++boatDisplay; 
        }

        /* 
        GameObject.Find("Boat" + (boatNo + 1)).GetComponent<Image>().enabled = true; 
        for (int i = 0; i < boats; ++i) {
            if (i != boatNo) {
                GameObject.Find("Boat" + (i + 1)).GetComponent<Image>().enabled = false; 
            }
        }
        //Debug.Log(GameObject.Find("Boat"+(1+1)).name); 
        */

        if (PlayerPrefs.GetString("bought", "0").Contains(boatDisplay.ToString())) {
            GameObject.Find("SceneReferences").GetComponent<SceneReferences>().boatSelections[boatDisplay].transform.GetChild(0).gameObject.SetActive(false);
        }

        GameObject.Find("SceneReferences").GetComponent<SceneReferences>().boatSelections[boatDisplay].SetActive(true); 
        for (int i = 0; i < boats; ++i) {
            if (i != boatDisplay) {
                GameObject.Find("SceneReferences").GetComponent<SceneReferences>().boatSelections[i].SetActive(false); 
            }
        }
        //Debug.Log(GameObject.Find("SceneReferences").GetComponent<SceneReferences>().boatSelections[boatNo].name); 

        RectTransform _speedBar = GameObject.Find("speedBar").GetComponent<RectTransform>();
        _speedBar.localScale = new Vector3((float)boatStats[boatDisplay, 0] / 15f, _speedBar.localScale.y, _speedBar.localScale.x);
        RectTransform _rotationBar = GameObject.Find("rotationBar").GetComponent<RectTransform>();
        _rotationBar.localScale = new Vector3((float)boatStats[boatDisplay, 1] / 1.5f, _rotationBar.localScale.y, _rotationBar.localScale.x);
        RectTransform _dragBar = GameObject.Find("dragBar").GetComponent<RectTransform>();
        _dragBar.localScale = new Vector3((float)boatStats[boatDisplay, 2] / 3f, _dragBar.localScale.y, _dragBar.localScale.x);
        RectTransform _angularBar = GameObject.Find("angularBar").GetComponent<RectTransform>();
        _angularBar.localScale = new Vector3((float)boatStats[boatDisplay, 3] / 3f, _angularBar.localScale.y, _angularBar.localScale.x);
        RectTransform _sizeBar = GameObject.Find("sizeBar").GetComponent<RectTransform>();
        _sizeBar.localScale = new Vector3((float)boatStats[boatDisplay, 4] / 1.6f, _sizeBar.localScale.y, _sizeBar.localScale.x); 
    }

    public void buyBoat(int _num) {
        int _price = prices[_num]; 
        int _score = PlayerPrefs.GetInt("score", 0);
        int _finalPrice = _score - _price;
        //Debug.Log(_finalPrice); 
        string _bought = PlayerPrefs.GetString("bought", "0"); 
        if (_finalPrice >= 0 && !_bought.Contains(_num.ToString())) {
            PlayerPrefs.SetInt("score", _finalPrice);
            GameObject.Find("scoreText").GetComponent<Text>().text = _finalPrice.ToString(); 
            PlayerPrefs.SetString("bought", _bought + _num); 
        }
    }

    public void selectBoat(int _num) {
        if (PlayerPrefs.GetString("bought", "0").Contains(_num.ToString())) {
            boatNo = _num; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") && Input.GetKey("k")) {
            //PlayerPrefs.SetInt("score", 1000);
            PlayerPrefs.SetInt("score", 0);
            PlayerPrefs.SetString("bought", "0");
            PlayerPrefs.SetInt("highscore", 0); 
            GameObject.Find("scoreText").GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString(); 
            GameObject.Find("highscore").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString(); 
        } else if (Input.GetKey("f") && Input.GetKey("n")) {
            PlayerPrefs.SetInt("score", 1000);
            GameObject.Find("scoreText").GetComponent<Text>().text = PlayerPrefs.GetInt("score", 0).ToString(); 
        }
    }
}
