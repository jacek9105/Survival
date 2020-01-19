using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HUD : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController Fpsc;
    bool decreaseStamina;

    static public float maxHP;
    static public float actualHP;

    static public float maxDesire;
    static public float actualDesire;

    static public float maxHunger;
    static public float actualHunger;

    static public float maxStamina;
    static public float actualStamina;

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
        actualDesire = Mathf.Clamp(actualDesire, 0, 100);
        actualHP = Mathf.Clamp(actualHP, 0, 100);
        actualHunger = Mathf.Clamp(actualHunger, 0, 100);
        actualStamina = Mathf.Clamp(actualStamina, 0, 100);

        hpBar.transform.localScale = new Vector3(actualHP / maxHP, 1, 0);
        desireBar.transform.localScale = new Vector3(actualDesire / maxDesire, 1, 0);
        hungerBar.transform.localScale = new Vector3(actualHunger / maxHunger, 1, 0);
        staminaBar.transform.localScale = new Vector3(actualStamina / maxStamina, 1, 0);

        actualDesire -= 0.5f * Time.deltaTime;
        actualHunger -= 0.25f * Time.deltaTime;

      

        if (actualDesire < 5 || actualHunger < 5)
        {
            actualHP -= 0.1f * Time.deltaTime;
        }
        else if(actualHP < maxHP)
        {
            actualHP += 1 * Time.deltaTime;
        }

        if (actualStamina < 0.75)
        {
            Fpsc.m_Jumping = false;
            Fpsc.m_IsWalking = true;
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
       



        if (actualHP <= 0.1)
        {
            Destroy(gameObject);
            // Matt dodaj okienko które pozwloić kliknąć koniec gry czy coś takiego i wróci do ekranu pierwszego.
        }
    }
}
