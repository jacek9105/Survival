using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Felling : MonoBehaviour
{
    
    public int  TreeHP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TreeHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
