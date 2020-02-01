using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour
{
    public List<Object> listOwnedItem = new List<Object>();
    public List<Object> listItemToolbar = new List<Object>();

    public Object objectDragg;
    static public bool didViewInventory;
   

    //public WeaponSwitch weaponSwitch;

    bool didObjectDragg;
    bool doShare;


    int numberSocketsX;
    int numberSocketsY;
    int numberSocketsToolbar =5;
    int previousSlot;
    public string displayDescription;

    public GameObject draggedObject;
    public GameObject FPSCon;
    public GUISkin skin;

    public Transform handPosition;

    float timeUseObject;

    // Start is called before the first frame update
    void Start()
    {
        doShare = false;
        displayDescription = null;
        didViewInventory = false;
        numberSocketsX = 5;
        numberSocketsY = 4;
        timeUseObject = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        displayDescription = null;

        if (Input.GetKeyUp(KeyCode.I))
        {
            didViewInventory = !didViewInventory;
            Cursor.visible = didViewInventory;//Ukrycie pokazanie kursora myszy.
            if (didViewInventory == true)
            {
                Crafting.didViewCrafting = false;
                Cursor.lockState = CursorLockMode.None;//Odblokowanie kursora myszy.
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            didViewInventory = false;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) { useObjectToolbar(listItemToolbar[0].id, 0, !listItemToolbar[0].isWeapon, listItemToolbar[0].isWeapon);}
        if (Input.GetKeyUp(KeyCode.Alpha2)) { useObjectToolbar(listItemToolbar[1].id, 1, !listItemToolbar[1].isWeapon, listItemToolbar[1].isWeapon); }
        if (Input.GetKeyUp(KeyCode.Alpha3)) { useObjectToolbar(listItemToolbar[2].id, 2, !listItemToolbar[2].isWeapon, listItemToolbar[2].isWeapon); }
        if (Input.GetKeyUp(KeyCode.Alpha4)) { useObjectToolbar(listItemToolbar[3].id, 3, !listItemToolbar[3].isWeapon, listItemToolbar[3].isWeapon); }
        if (Input.GetKeyUp(KeyCode.Alpha5)) { useObjectToolbar(listItemToolbar[4].id, 4, !listItemToolbar[4].isWeapon, listItemToolbar[4].isWeapon); }

        if (Input.GetKeyUp(KeyCode.G))
        {
            discardItem();
        }


    }

    private void discardItem()
    {
        int i = 0;
        draggedObject.transform.parent = null;
        draggedObject.GetComponent<Rigidbody>().useGravity = true;
        draggedObject.GetComponent<Rigidbody>().isKinematic = false;
        didObjectDragg = false;
        for(int x = 1; x < listOwnedItem.Count; x++)
        {
            if (listOwnedItem[i].id == draggedObject.GetComponent<itemToLift>().id)
            {
                if (listOwnedItem[i].stackedQuantity > 1)
                {
                    listOwnedItem[i].stackedQuantity -= 1;
                }
                if (listOwnedItem[i].stackedQuantity == 1)
                {
                    listOwnedItem[i] = new Object();
                }
            }
        }
    }

    void OnGUI()
    {
        toolbar();
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

    void toolbar()
    {
        int i = 0;
        for(int j=0;j<numberSocketsToolbar;j++)
        {
            Rect toolbarLocation = new Rect(Screen.width * 0.35f + (j * Screen.width * 0.075f), Screen.height * 0.85f , Screen.width * 0.07f, Screen.height * 0.13f);
            GUI.Box(toolbarLocation, "", skin.GetStyle("slotEkwipunku"));

            if(listItemToolbar[i].id != 0)
            {
                GUI.DrawTexture(toolbarLocation, listItemToolbar[i].objectIcons);
                GUI.Box(toolbarLocation, listItemToolbar[i].stackedQuantity.ToString(), skin.GetStyle("stackedQuantityStyle"));
            }

            if(toolbarLocation.Contains (Event.current.mousePosition) && Event.current.type == EventType.MouseUp && listItemToolbar[i].id ==0 && didObjectDragg == true)
            {
                listItemToolbar[i] = new Object(objectDragg.id, objectDragg.name, objectDragg.description, objectDragg.isWeapon, objectDragg.stackedQuantity);
                didObjectDragg = false;
                doShare = false;
            }

            if (didViewInventory == true && toolbarLocation.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseDrag && didObjectDragg == false)
            {
                objectDragg = listItemToolbar[i];
                listItemToolbar[i] = new Object();
                didObjectDragg = true;
            }

            //używanie przedmiotów
            if (toolbarLocation.Contains(Event.current.mousePosition) && Input.GetMouseButtonUp(1))
            {
                useObjectToolbar(listItemToolbar[i].id, i, !listItemToolbar[i].isWeapon, listItemToolbar[i].isWeapon);
            }

            i++;
        }

    }

    void viewInventory()
    {
        int i = 0;
        GUI.Box(new Rect(Screen.width * 0.10f, Screen.height * 0.05f, Screen.width * 0.28f, Screen.height * 0.01f), "INVENTORY", skin.GetStyle("inventoryText"));

        for (int x=0; x<numberSocketsX; x++)
        {
            for(int y=0; y<numberSocketsY; y++)
            {
                Rect slotLocation = new Rect(Screen.width * 0.05f + (x * Screen.width * 0.075f), Screen.height * 0.05f + (y * Screen.height * 0.13f), Screen.width * 0.07f, Screen.height * 0.13f);
                GUI.Box(slotLocation, "", skin.GetStyle("slotEkwipunku"));

                if (listOwnedItem[i].id != 0)
                {
                    GUI.DrawTexture(slotLocation, listOwnedItem[i].objectIcons);
                    GUI.Box(slotLocation, listOwnedItem[i].stackedQuantity.ToString(), skin.GetStyle("stackedQuantityStyle"));

                }

                //Dzielenie ilości w stacku
                if (Input.GetKey(KeyCode.LeftShift) && slotLocation.Contains(Event.current.mousePosition) && listOwnedItem[i].stackedQuantity > 1 && Event.current.type == EventType.MouseDrag && didObjectDragg == false)
                {
                    didObjectDragg = true;
                    doShare = true;
                    if (listOwnedItem[i].stackedQuantity % 2 > 0)
                    {
                        listOwnedItem[i].stackedQuantity = Mathf.Round(listOwnedItem[i].stackedQuantity / 2 + 0.15f);
                        objectDragg = new Object(listOwnedItem[i].id, listOwnedItem[i].name, listOwnedItem[i].description, listOwnedItem[i].isWeapon, listOwnedItem[i].stackedQuantity);
                        objectDragg.stackedQuantity = listOwnedItem[i].stackedQuantity - 1;
                    }
                    else if (listOwnedItem[i].stackedQuantity %2 == 0)
                    {
                        listOwnedItem[i].stackedQuantity = listOwnedItem[i].stackedQuantity / 2;
                        objectDragg = listOwnedItem[i];
                        objectDragg.stackedQuantity = listOwnedItem[i].stackedQuantity;
                    }
                }

                //Łączenie przedmiotów w stacku
                if (didObjectDragg == true && objectDragg.id == listOwnedItem[i].id && objectDragg != null && slotLocation.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseUp && listOwnedItem[i].stackedQuantity + objectDragg.stackedQuantity <= pickingUpItem.maxStack)
                {
                    listOwnedItem[i] = new Object(objectDragg.id, objectDragg.name, objectDragg.description, objectDragg.isWeapon, listOwnedItem[i].stackedQuantity + objectDragg.stackedQuantity);
                    didObjectDragg = false;
                    objectDragg = null;

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
                    listOwnedItem[i] = new Object(objectDragg.id, objectDragg.name, objectDragg.description, objectDragg.isWeapon, objectDragg.stackedQuantity);
                    didObjectDragg = false;
                    doShare = false;
                }

                if (slotLocation.Contains(Event.current.mousePosition) && Event.current.type == EventType.MouseUp && listOwnedItem[i].id > 0 && didObjectDragg == true && doShare == false)
                {
                    listOwnedItem[previousSlot] = listOwnedItem[i];
                    listOwnedItem[i] = objectDragg;
                    didObjectDragg = false;
                }
                //używanie przedmiotów
                if (slotLocation.Contains(Event.current.mousePosition) && Input.GetMouseButtonUp(1))
                {
                    useObject(listOwnedItem[i].id, i, !listOwnedItem[i].isWeapon, listOwnedItem[i].isWeapon);
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
        if (isWeapon == true && didObjectDragg == false)
        {
            if(id == 1)
            {
                WeaponSwitch.isAvaible2 = true;
                WeaponSwitch.weaponSelected = 2;
                WeaponSwitch.didChange = true;
                //listOwnedItem[slotNumber] = new Object();
            }
            if (id == 6)
            {
                WeaponSwitch.isAvaible1 = true;
                WeaponSwitch.weaponSelected = 1;
                WeaponSwitch.didChange = true;
                //listOwnedItem[slotNumber] = new Object();
            }
            /*
            GameObject objekt = Instantiate(listOwnedItem[slotNumber].prefabObject, handPosition.position, handPosition.rotation);
            objekt.name = listOwnedItem[slotNumber].name;
            objekt.transform.parent = FPSCon.transform;
            draggedObject= objekt;
            didObjectDragg = true;
            */
        }

        if (isWeapon == true && didObjectDragg == true)
        {
            Destroy(draggedObject.gameObject);
            GameObject objekt = Instantiate(listOwnedItem[slotNumber].prefabObject, handPosition.position, handPosition.rotation);
            objekt.name = listOwnedItem[slotNumber].name;
            objekt.transform.parent = FPSCon.transform;
            draggedObject = objekt;
            
        }

        if (didDelete == true && listOwnedItem[slotNumber].stackedQuantity == 1 && timeUseObject + 0.1f < DayNightCycle.actualTime)
        {
            listOwnedItem[slotNumber] = new Object();
            if (id == 3)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25; } else { HUD.actualDesire = 100; }
            }
            if (id == 4)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 15; } else { HUD.actualHunger = 100; }
            }
            if(id==5)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 8)
            {
                if (HUD.actualHP <= 75) { HUD.actualHP += 25; } else { HUD.actualHP = 100; }
            }
            if (id == 9)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 30; } else { HUD.actualHunger = 100; }
            }
            if (id == 12)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25; } else { HUD.actualDesire = 100; }
            }
        }
        else if (didDelete == true && listOwnedItem[slotNumber].stackedQuantity > 1 && timeUseObject + 0.1f < DayNightCycle.actualTime)
        {
            timeUseObject = DayNightCycle.actualTime;
            listOwnedItem[slotNumber].stackedQuantity -= 1;
            if (id == 3)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25;  } else { HUD.actualDesire = 100; }
            }
            if (id == 4)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 5)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 8)
            {
                if (HUD.actualHP <= 75) { HUD.actualHP += 25; } else { HUD.actualHP = 100; }
            }
            if (id == 9)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 30; } else { HUD.actualHunger = 100; }
            }
            if (id == 12)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25; } else { HUD.actualDesire = 100; }
            }
        }
    }

    void useObjectToolbar(int id, int slotNumber, bool didDelete, bool isWeapon)
    {
        if (isWeapon == true && didObjectDragg == false)
        {
            if (id == 1)
            {
                WeaponSwitch.isAvaible2 = true;
                WeaponSwitch.weaponSelected = 2;
                WeaponSwitch.didChange = true;
                //listOwnedItem[slotNumber] = new Object();
            }
            if (id == 6)
            {
                WeaponSwitch.isAvaible1 = true;
                WeaponSwitch.weaponSelected = 1;
                WeaponSwitch.didChange = true;
                //listOwnedItem[slotNumber] = new Object();
            }
        }
            if (didDelete == true && listItemToolbar[slotNumber].stackedQuantity == 1 && timeUseObject + 0.1f < DayNightCycle.actualTime)
             {
            listItemToolbar[slotNumber] = new Object();
            if (id == 3)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25; } else { HUD.actualDesire = 100; }
            }
            if (id == 4)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 5)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 8)
            {
                if (HUD.actualHP <= 75) { HUD.actualHP += 25; } else { HUD.actualHP = 100; }
            }
            if (id == 9)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 30; } else { HUD.actualHunger = 100; }
            }
        }
        else if (didDelete == true && listItemToolbar[slotNumber].stackedQuantity > 1 && timeUseObject + 0.1f < DayNightCycle.actualTime)
        {
            timeUseObject = DayNightCycle.actualTime;
            listItemToolbar[slotNumber].stackedQuantity -= 1;
            if (id == 3)
            {
                if (HUD.actualDesire <= 75) { HUD.actualDesire += 25; } else { HUD.actualDesire = 100; }
            }
            if (id == 4)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 5)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 25; } else { HUD.actualHunger = 100; }
            }
            if (id == 8)
            {
                if (HUD.actualHP <= 75) { HUD.actualHP += 25; } else { HUD.actualHP = 100; }
            }
            if (id == 9)
            {
                if (HUD.actualHunger <= 75) { HUD.actualHunger += 30; } else { HUD.actualHunger = 100; }
            }
        }
    }

    //skróty klawiszowe


}
