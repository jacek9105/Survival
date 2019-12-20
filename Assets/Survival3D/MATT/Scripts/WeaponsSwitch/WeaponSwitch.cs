using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    
    int weaponSelected = 1;

    [SerializeField]
    GameObject primary, secondary, melee;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        //anim = GetComponentInChildren<Animator> ();
        SwapWeapon(1);
    }

    void Update()
    {
        if (Input.GetKeyDown("5"))
         {
             anim.Play("Swing01", -1,0f);
         }
         



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(weaponSelected != 1)
            {
                SwapWeapon(1);              
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
            }
        }

    }

    void SwapWeapon(int weaponType)
    {
        if(weaponType == 1)
        {
            primary.SetActive(true);
            secondary.SetActive(false);
            melee.SetActive(false);

            weaponSelected = 1;
        }

        if (weaponType == 2)
        {
            primary.SetActive(false);
            secondary.SetActive(true);
            melee.SetActive(false);

            weaponSelected = 2;
        }

        if (weaponType == 3)
        {
            primary.SetActive(false);
            secondary.SetActive(false);
            melee.SetActive(true);

            weaponSelected = 3;
        }
    }
}
