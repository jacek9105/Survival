﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    public List<Object> listOwnedItem = new List<Object>();

    bool didViewInventory;
    int numberSocketsX;
    int numberSocketsY;

    public GUISkin skin;
    // Start is called before the first frame update
    void Start()
    {
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
        } 

    }

    private void OnGUI()
    {
        if (didViewInventory == true)
        {
            viewInventory();
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
                }

                if(slotLocation.Contains(Event.current.mousePosition)  && Input.GetMouseButtonUp(0))
                {
                    useObject(listOwnedItem[i].id, i, true);
                }
                i++;
            } 
        }

    }

    void useObject(int id, int slotNumber, bool didDelete)
    {

        if (didDelete)
        {
            listOwnedItem[slotNumber] = new Object();
        }

    }
}
