using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController Fpsc;
    bool decreaseStamina;
    public GameObject damage;

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

    [Header("DamageScreen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmothing = 6f;
    public static bool isTakingDamage = false;

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

        hpBar.transform.localScale = new Vector3(Screen.width*0.07f*actualHP/maxHP, Screen.height*0.10f, 0);
        hpBar.transform.position = new Vector3(Screen.width * 0.07f, Screen.height * 0.05f, 1);

        hungerBar.transform.localScale = new Vector3(Screen.width * 0.07f * actualHunger / maxHunger, Screen.height * 0.10f, 0);
        hungerBar.transform.position = new Vector3(Screen.width * 0.13f, Screen.height * 0.05f, 1);

        desireBar.transform.localScale = new Vector3(Screen.width * 0.07f * actualDesire / maxDesire, Screen.height * 0.10f, 0);
        desireBar.transform.position = new Vector3(Screen.width * 0.19f, Screen.height * 0.05f, 1);

        staminaBar.transform.localScale = new Vector3(Screen.width * 0.07f * actualStamina / maxStamina, Screen.height * 0.10f, 0);
        staminaBar.transform.position = new Vector3(Screen.width * 0.25f, Screen.height * 0.05f, 1);

        actualDesire -= 0.2f * Time.deltaTime;
        actualHunger -= 0.1f * Time.deltaTime;

        if(isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color,Color.clear, colorSmothing * Time.deltaTime);
        }
      

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

        isTakingDamage = false;
    }
}
