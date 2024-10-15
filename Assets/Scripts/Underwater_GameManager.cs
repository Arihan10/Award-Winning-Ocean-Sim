using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Underwater_GameManager : MonoBehaviour {
    public GameObject[] trashes; 
    public Text _countdown; 

    GameObject _trash; 
    Rigidbody rb;

    private float newSize;
    public int endtime = 30; 

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 1000; ++i) {
            _trash = Instantiate(trashes[Random.Range(0,trashes.Length-1)], new Vector3(Random.Range(-2374f, 2374f), Random.Range(0, 10f), Random.Range(-2374f, 2374f)), Quaternion.identity);
            Destroy(_trash.transform.GetChild(0).gameObject); 
            rb = _trash.GetComponent<Rigidbody>(); 
            rb.useGravity = true; 
            rb.drag = 0.5f;
            //newSize = Random.Range(-0.5f, 3f); 
            //_trash.transform.localScale += new Vector3(newSize, newSize, newSize); 
            //_trash.AddComponent(typeof(CapsuleCollider)); 
        }

        StartCoroutine(Countdown()); 
    }

    IEnumerator Countdown () {
        for (int i = 0; i < endtime; ++i) {
            _countdown.text = (endtime - i).ToString(); 
            yield return new WaitForSeconds(1f); 
        }
        SceneSwitch(); 
    }

    private void SceneSwitch() {
        SceneManager.LoadScene("GameLevel"); 
    }

    // Update is called once per frame
    void Update() {

    }
}