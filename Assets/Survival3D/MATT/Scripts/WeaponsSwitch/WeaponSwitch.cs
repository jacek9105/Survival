using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    static public int weaponSelected;
    static public bool isAvaible1, isAvaible2, didChange;

    [SerializeField]
    GameObject primary, secondary, melee;

    void Start()
    {
        SwapWeapon(3);
        isAvaible1 = false;
        isAvaible2 = false;
        didChange = false;

    }

    void Update()
    {
        if (weaponSelected == 1 && didChange == true)
        {
            SwapWeapon(1);

            didChange = false;
        }
        if (weaponSelected == 2 && didChange == true)
        {
            SwapWeapon(2);

            didChange = false;
        }

        if (Input.GetKeyDown(KeyCode.F1) && isAvaible1 == true)
        {
            if (weaponSelected != 1)
            {
                SwapWeapon(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.F2) && isAvaible2 == true)
        {
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
            }
        }



    }


    public void SwapWeapon(int weaponType)
    {
        if (weaponType == 1)
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
