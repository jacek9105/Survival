﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    public List<Object> listOwnedItem = new List<Object>();
    public Object objectDragg;
    public bool didViewInventory;

    bool didObjectDragg;
    int numberSocketsX;
    int numberSocketsY;
    int previousSlot;
    public string displayDescription;

    public GameObject FPSCon;
    public GUISkin skin;
    public Transform handPosition;

    // Start is called before the first frame update
    void Start()
    {
        displayDescription = null;
        didViewInventory = false;
        numberSocketsX = 5;
        numberSocketsY = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            didViewInventory = !didViewInventory;
        

            Cursor.visible = didViewInventory;//Ukrycie pokazanie kursora myszy.
            if (didViewInventory == true)
            {
                //Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = true;//Pokazanie kursora.
                Cursor.lockState = CursorLockMode.None;//Odblokowanie kursora myszy.
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            didViewInventory = false;
        }

    }


    void OnGUI()
    {
        if (didViewInventory == true)
        {
            viewInventory();
        }
        if (didObjectDragg == true)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), objectDragg.objectIcons);
        }
        if (displayDescription != null)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 150, 50), displayDescription);
        }
    }

    void viewInventory()
    {
        int i = 0;

        for(int x=0; x<numberSocketsX; x++)
        {
            for(int y=0; y<numberSocketsY; y++)
            {
                Rect slotLocation = new Rect(Screen.width * 0.05f + (x * Screen.width * 0.075f), Screen.height * 0.05f + (y * Screen.height * 0.13f), Screen.width * 0.07f, Screen.height * 0.13f);
                GUI.Box(slotLocation, "", skin.GetStyle("slotEkwipunku"));

                if(listOwnedItem[i].id != 0)
                {
                    GUI.DrawTexture(slotLocation, listOwnedItem[i].objectIcons);
                    GUI.Box(slotLocation, listOwnedItem[i].stackedQuantity.ToString(), skin.GetStyle("stackedQuantityStyle"));
                    
                }
                //Przenoszenie
                if(slotLocation.Contains(Event.current.mousePosition)  && Event.current.type == EventType.MouseDrag && didObjectDragg == false)
                {
                    objectDragg = listOwnedItem[i];
                    listOwnedItem[i] = new Object();
                    didObjectDragg = true;
                    previousSlot = i;
                }

                if (slotLocation.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseUp && listOwnedItem[i].id == 0 && didObjectDragg == true)
                {
                    listOwnedItem[i] = objectDragg;
                    didObjectDragg = false;
                }

                if (slotLocation.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseUp && listOwnedItem[i].id > 0 && didObjectDragg == true)
                {
                    listOwnedItem[previousSlot] = listOwnedItem[i];
                    listOwnedItem[i] = objectDragg;
                    didObjectDragg = false;
                }
                //usuwanie przedmiotów
                if (slotLocation.Contains(Event.current.mousePosition) && Input.GetMouseButtonUp(1))
                {
                    useObject(listOwnedItem[i].id, i, true, listOwnedItem[i].isWeapon);
                }

                // wyświetlanie informacji o przedmiotach
                if (slotLocation.Contains(Event.current.mousePosition) && listOwnedItem[i].id !=0 )
                {
                    displayDescription = listOwnedItem[i].description;

                }
                else if(slotLocation.Contains(Event.current.mousePosition) && listOwnedItem[i].id == 0)
                {
                    displayDescription = null;
                }

                i++;
                
            } 
        }

    }

    void useObject(int id, int slotNumber, bool didDelete, bool isWeapon)
    {
        if (isWeapon == true)
        {
            GameObject objekt = Instantiate(listOwnedItem[slotNumber].prefabObject, handPosition.position, handPosition.rotation);
            objekt.name = listOwnedItem[slotNumber].name;
            objekt.transform.parent = FPSCon.transform;
        }
        if (didDelete)
        {
            listOwnedItem[slotNumber] = new Object();
        }

    }
}
