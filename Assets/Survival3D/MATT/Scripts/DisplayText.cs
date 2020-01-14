using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {
    public GameObject UIObject;
    public GameObject Cube;
 
    void Start()
    {
        UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIObject.SetActive(true);
        }

    }

    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        UIObject.SetActive(false);
        //Destroy(Cube);
    }
}
