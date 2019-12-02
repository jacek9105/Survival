using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Felling : MonoBehaviour
{
    
    public int  TreeHP;
    public Rigidbody rigidBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TreeHP <= 0)
        {
            rigidBody.isKinematic = false;
           
        }
    }
}
