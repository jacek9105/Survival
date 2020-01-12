using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && equipment.didViewInventory == false && Crafting.didViewCrafting == false)
        {
            anim.Play("Run", -1, 0f);
        }
        
        if (Input.GetMouseButtonDown(0) && equipment.didViewInventory == false && Crafting.didViewCrafting == false)
        {
            anim.Play("Swing01", -1, 0f);
        }
           
        if (Input.GetMouseButtonDown(1) && equipment.didViewInventory == false && Crafting.didViewCrafting == false)
        {
            anim.Play("Swing02", -1, 0f);
        }

        if (Input.GetMouseButtonDown(2) && equipment.didViewInventory == false && Crafting.didViewCrafting == false)
        {
            anim.Play("PunchLeft", -1, 0f);
        }
    }
}
