﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Felling : MonoBehaviour
{

    public int TreeHP;
    public Rigidbody rigidBody;
    void Start()
    {
        TreeHP = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (TreeHP == 0)
        {
            rigidBody.isKinematic = false;
            
        }
        if (TreeHP == -2)
        {
            Destroy(gameObject);
        }

    }
}
