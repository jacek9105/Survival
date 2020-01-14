using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigHP : MonoBehaviour
{

    public int pigHealtPoints;
   
    public Transform meal; 
    public GameObject pig;
    void Start()
    {
        pigHealtPoints = 4;
        pig = this.gameObject; //new
       
    }

    // Update is called once per frame
    void Update()
    {
        if (pigHealtPoints <= 0)
        {
            PigDestroy(); // new
        }
        /*
            if(TreeHP == -2)
        {
            Destroy(gameObject);
        }
        */

    }
    void PigDestroy()  //new 
    {
        Destroy(gameObject);
                
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(meal, pig.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        Instantiate(meal, pig.transform.position + new Vector3(2, 0, 0) + position, Quaternion.identity);
       


    }

}
