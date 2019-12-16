﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUpItem : MonoBehaviour
{
    public GameObject itemToPick;
    public GUISkin skin;
    bool canLift;
    bool didStacked; 

    int idItem;
    int maxStack;

    public equipment equipment;
    // Start is called before the first frame update
    void Start()
    {
        maxStack = 5;
        didStacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLift == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                idItem = itemToPick.GetComponent<itemToLift>().id;

                if (didStacked == true)
                {
                    for (int i = 0; i < equipment.listOwnedItem.Count; i++)
                    {
                        if (idItem == equipment.listOwnedItem[i].id && itemToPick != null && equipment.listOwnedItem[i].stackedQuantity < maxStack)
                        {
                            equipment.listOwnedItem[i].stackedQuantity += 1;
                            Destroy(itemToPick);
                            itemToPick = null;
                            didStacked = true;
                            break;
                        }
                        else { didStacked = false; }
                    }
                }
                if (didStacked == false)
                {
                    for (int i = 0; i < equipment.listOwnedItem.Count; i++)
                    {
                        if (equipment.listOwnedItem[i].id == 0 && itemToPick != null)
                        {
                            equipment.listOwnedItem[i] = new Object(Database.itemList[idItem].id, Database.itemList[idItem].name, Database.itemList[idItem].description, Database.itemList[idItem].isWeapon, Database.itemList[idItem].stackedQuantity);
                            Destroy(itemToPick);
                            itemToPick = null;
                            didStacked = true;
                        }
                    }
                }


            }
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("itemToPick"))
        {
            itemToPick = col.gameObject;
            canLift = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("itemToPick"))
        {
            itemToPick = null;
            canLift = false;
        }
    }

    private void OnGUI()
    {
        if (canLift == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Push e to lift item", skin.GetStyle("Lift"));
        }
    }
}