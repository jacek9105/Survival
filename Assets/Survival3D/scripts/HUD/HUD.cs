using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController Fpsc;
    bool decreaseStamina;

    public float maxHP;
    public float actualHP;

    public float maxDesire;
    public float actualDesire;

    public float maxHunger;
    public float actualHunger;

    public float maxStamina;
    public float actualStamina;

    public GameObject hpBar;
    public GameObject desireBar;
    public GameObject hungerBar;
    public GameObject staminaBar;
    void Start()
    {
        decreaseStamina = false;

        maxHP = 100;
        maxHunger = 100;
        maxDesire = 100;
        maxStamina = 100;

        actualHP = 100;
        actualDesire = 100;
        actualHunger = 100;
        actualStamina = 100;
    }


    void Update()
    {
        hpBar.transform.localScale = new Vector3(actualHP / maxHP, 1, 0);
        desireBar.transform.localScale = new Vector3(actualDesire / maxDesire, 1, 0);
        hungerBar.transform.localScale = new Vector3(actualHunger / maxHunger, 1, 0);
        staminaBar.transform.localScale = new Vector3(actualStamina / maxStamina, 1, 0);

        actualDesire -= 0.1f * Time.deltaTime;
        actualHunger -= 0.1f * Time.deltaTime;

      

        if (actualStamina < 0)
        {
            actualStamina = 0;
        }
        if (actualHP <0)
        {
            actualHP = 0;
        }
        if (actualHunger < 0)
        {
            actualHunger = 0;
        }
        if (actualDesire < 0)
        {
            actualDesire = 0;
        }



        if(actualDesire < 5 || actualHunger < 5)
        {
            actualHP -= 0.1f * Time.deltaTime;
        }
        else if(actualHP < maxHP)
        {
            actualHP += 1 * Time.deltaTime;
        }


        
        if (Fpsc.m_IsWalking == false)
        {
            actualStamina -= 1 * Time.deltaTime;
        }
            else if (actualStamina < maxStamina)
            {
            actualStamina += 1 * Time.deltaTime;
            }

        if (Fpsc.m_Jumping == true && decreaseStamina == false)
        {
            decreaseStamina = true;
            actualStamina = actualStamina - 5;
        }
            else if(Fpsc.m_Jumping == false)
            {
            decreaseStamina = false;
            }
                else if(actualStamina < maxStamina)
                { 
                actualStamina += 1 * Time.deltaTime;
                }
    }
}
