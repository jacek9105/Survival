using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.Play("Run", -1, 0f);
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Swing01", -1, 0f);
        }
           
        if (Input.GetMouseButtonDown(1))
        {
            anim.Play("Swing02", -1, 0f);
        }
            
    }
}
