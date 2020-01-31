using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Database Database;
    public equipment equipment;
    public GUISkin skin;
    public GameObject raftsail;
    int numberSocketsX;
    int numberSocketsY;
    static public bool didViewCrafting;
    public string info;
    bool haveId1;
    bool haveId2;
    bool haveId3;
    bool haveId4;
    bool canCraft;
    bool haveNeededQuantity1; // 3 zmienne bo mamy 3 rozne rodzaje przedmiotow uzywanych w craftingu
    bool haveNeededQuantity2;
    bool haveNeededQuantity3;
    bool haveNeededQuantity4;
    private float timeCraftingItem;
    bool craftedItem;
    bool didStacked;
    int maxStack = 3;
    float itemCounter;
    float time;
    public bool rescueBoat;
    void Start()
    {
        numberSocketsX = 5;
        numberSocketsY = 4;
        info = null;
        time = 1;
        rescueBoat = false;
        raftsail.SetActive(false);
    }


    void Update()
    {
        info = null;
        if (Input.GetKeyDown(KeyCode.P))
        {
            didViewCrafting = !didViewCrafting;
            Cursor.visible = didViewCrafting;//Ukrycie pokazanie kursora myszy.
            if (didViewCrafting == true)
            {
                Cursor.lockState = CursorLockMode.None;//Odblokowanie kursora myszy.
                equipment.didViewInventory = false;
              
            }


        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            didViewCrafting = false;
        }
        if(craftedItem == true)
        {
            time -= 1 * Time.deltaTime;
            if(time <= 0)
            {
                craftedItem = false;
                time = 1;
            }
        }
    }
    private void OnGUI()
    {
        if (didViewCrafting == true && equipment.didViewInventory == false)
        {
            viewCrafiting();
        }
        if(info != null)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 150, 75), info);
        }
    }
    void viewCrafiting()
    {
        
        int i = 0;
        GUI.Box(new Rect(Screen.width * 0.10f, Screen.height * 0.05f, Screen.width * 0.28f, Screen.height * 0.01f), "CRAFTING", skin.GetStyle("inventoryText"));
        for (int x = 0; x < numberSocketsX; x++)
        {
            for (int y = 0; y < numberSocketsY; y++)
            {
                Rect slotLocation = new Rect(Screen.width * 0.05f + (x * Screen.width * 0.075f), Screen.height * 0.05f + (y * Screen.height * 0.13f), Screen.width * 0.07f, Screen.height * 0.13f);
                GUI.Box(slotLocation, "", skin.GetStyle("slotCraftingu"));
                if(Database.itemCraftingList[i].id != 0)
                {
                GUI.DrawTexture(slotLocation, Database.itemCraftingList[i].objectIcons);
                }
               
                if (slotLocation.Contains(Event.current.mousePosition) && Database.itemCraftingList[i].id !=0)
                {
                    CraftingInfo(Database.itemCraftingList[i].id);
                }
                else if (slotLocation.Contains(Event.current.mousePosition) && Database.itemCraftingList[i].id == 0)
                {
                    info = null;
                }

                if (slotLocation.Contains(Event.current.mousePosition) && Input.GetMouseButtonUp(0) && timeCraftingItem + 1 < DayNightCycle.actualTime && craftedItem == false)
                {
                    //craftedItem = false;
                    timeCraftingItem = DayNightCycle.actualTime;
                    CreateItem(Database.itemCraftingList[i].id);
                    
                }
                i++;
            }
        }
    }
    // dla kazdego przedmiotu z database z craftingu musimy tutaj wpisac info id musi sie zgadzac
    void CraftingInfo(int id)
    {

        if (id == 3) // butelka
        {
            info = "Needed items:" + "\n" + "trunk";
        }
        if (id == 1) // axe
        {
            info = "Needed items:" + "\n" + "trunk" + "\n" + "bottle";
        }
        if(id == 10) // rescue boat
        {
            info = "Needed items:" + "\n" + "3x trunks" + "\n" + "2x ropes" + "\n" + "1x sail";
        }
        if (id == 8) // apteczka
        {
            info = "Needed items:" + "\n" + "2x meal";
        }

    }
    
    void CreateItem(int id)
    {
        if(id == 1)
        {
            CheckItem(2,3); //sprawdzamy jeden item
          
            
            if (canCraft == true) //&& craftedItem == false
            {
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if(equipment.listOwnedItem[x].id == 2)
                    {
                        if(equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            
                            break;
                        }
                        else 
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            break;
                        }
                    }
                }
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if (equipment.listOwnedItem[x].id == 3)
                    {
                        if (equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            canCraft = false;
                            //craftedItem = true;
                            addItem(1);
                            break;
                        }
                        else
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            canCraft = false;
                            //craftedItem = true;
                            addItem(1);
                            break;
                        }
                    }
                }
            }
        }
  /*     -----------------============KOMENTARZ DLA TESTOW DLA NEXT IF=========-------------------
   *     if (id == 3)
        {
            CheckItem(2);
            if (canCraft == true) //&& craftedItem == false
            {
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if (equipment.listOwnedItem[x].id == 2)
                    {
                        if (equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            canCraft = false;
                            //craftedItem = true;
                            addItem(3);
                            break;
                        }
                        else
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            canCraft = false;
                            //craftedItem = true;
                            addItem(3);
                            break;
                        }
                    }
                }
            }
        }
    */
        // -----------------=================CRAFTING Z WYKORZYSTANIEM WIECEJ PRZEDMIOTOW JEDNEGO RODZAJU!!!!===============-------------
        if (id == 3)
        {
            CheckItem(2,0,0,0,3); // podajemy ile przedmiotow ktorego rodzaju potrzebujemy!! wywolujemy funkcje checkitem!!
            if (canCraft == true) //&& craftedItem == false
            {
                addItem(3);
                for(int i =0; i<3;i++)  // musimy wykonac nastepny for tyle razy ile potrzebujemy przedmiotow!! i musi być mniejsze od ilosci itemow ktore potrzebujemy
                {                         
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if (equipment.listOwnedItem[x].id == 2)
                    {
                        if (equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            canCraft = false;
                            //craftedItem = true;
                            
                            break;
                        }
                        else
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            canCraft = false;
                            //craftedItem = true;
                            
                            break;
                        }
                    }
                }
            }
        }
        }

// ------------------------====================CAFTING AID KIT +25HP-----------===================================
        if (id == 8)
        {
            CheckItem(5,0,0,0,2); // podajemy ile przedmiotow ktorego rodzaju potrzebujemy!! wywolujemy funkcje checkitem!!
            if (canCraft == true) //&& craftedItem == false
            {
                addItem(8);
                for (int i = 0; i < 3; i++)  // musimy wykonac nastepny for tyle razy ile potrzebujemy przedmiotow!! i musi być mniejsze od ilosci itemow ktore potrzebujemy
                {
                    for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                    {
                        if (equipment.listOwnedItem[x].id == 5)
                        {
                            if (equipment.listOwnedItem[x].stackedQuantity > 1)
                            {
                                equipment.listOwnedItem[x].stackedQuantity -= 1;
                                canCraft = false;
                                //craftedItem = true;

                                break;
                            }
                            else
                            if (equipment.listOwnedItem[x].stackedQuantity == 1)
                            {
                                equipment.listOwnedItem[x] = new Object();
                                canCraft = false;
                                //craftedItem = true;

                                break;
                            }
                        }
                    }
                }
            }
        }

        //     ------------------------===============RESCUE BOAT CRAFTING===============------------------
        if (id == 10)
        {
            CheckItem(2, 7, 11, 0, 3, 2, 1,0); // podajemy ile przedmiotow ktorego rodzaju potrzebujemy!! wywolujemy funkcje checkitem!!
            if (canCraft == true) //&& craftedItem == false
            {
                addItem(10);
                rescueBoat = true;
                raftsail.SetActive(true);
                for (int i = 0; i < 3; i++)  // musimy wykonac nastepny for tyle razy ile potrzebujemy przedmiotow!! i musi być mniejsze od ilosci itemow ktore potrzebujemy
                {
                    for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                    {
                        if (equipment.listOwnedItem[x].id == 2)
                        {
                            if (equipment.listOwnedItem[x].stackedQuantity > 1)
                            {
                                equipment.listOwnedItem[x].stackedQuantity -= 1;
                                canCraft = false;
                                //craftedItem = true;
                                break;
                            }
                            else
                            if (equipment.listOwnedItem[x].stackedQuantity == 1)
                            {
                                equipment.listOwnedItem[x] = new Object();
                                canCraft = false;
                                //craftedItem = true;

                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 3; i++)  // musimy wykonac nastepny for tyle razy ile potrzebujemy przedmiotow!! i musi być mniejsze od ilosci itemow ktore potrzebujemy
                {
                    for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                    {
                        if (equipment.listOwnedItem[x].id == 7)
                        {
                            if (equipment.listOwnedItem[x].stackedQuantity > 1)
                            {
                                equipment.listOwnedItem[x].stackedQuantity -= 1;
                                canCraft = false;
                                //craftedItem = true;
                                break;
                            }
                            else
                            if (equipment.listOwnedItem[x].stackedQuantity == 1)
                            {
                                equipment.listOwnedItem[x] = new Object();
                                canCraft = false;
                                //craftedItem = true;

                                break;
                            }
                        }
                    }
                }
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if (equipment.listOwnedItem[x].id == 11)
                    {
                        if (equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            canCraft = false;
                            //craftedItem = true;
                            break;
                        }
                        else
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            canCraft = false;
                            //craftedItem = true;

                            break;
                        }
                    }
                }
            }
        }







        /*
        --------------------=======================TWORZYMY KOLEJNY ITEM====================----------------
        if (id == 3) // id == kolejnu id z itemcrafting list z database 
        {
            CheckItem(2); //id itemu z itemlist z database
            if (canCraft == true) //&& craftedItem == false
            {
                for (int x = 0; x < equipment.listOwnedItem.Count; x++)
                {
                    if (equipment.listOwnedItem[x].id == 2)
                    {
                        if (equipment.listOwnedItem[x].stackedQuantity > 1)
                        {
                            equipment.listOwnedItem[x].stackedQuantity -= 1;
                            canCraft = false;
                            //craftedItem = true;
                            addItem(3);
                            break;
                        }
                        else
                        if (equipment.listOwnedItem[x].stackedQuantity == 1)
                        {
                            equipment.listOwnedItem[x] = new Object();
                            canCraft = false;
                            //craftedItem = true;
                            addItem(3);
                            break;
                        }
                    }
                }
            }
        }
        */


    }

    void CheckItem(int id1, int id2, int id3 = 0, int id4 = 0, float count1 = 1, float count2 = 0, float count3 = 0, float count4=0) //tyle zmiennych ile id w craftingu database
    {
        canCraft = false;
        itemCounter = 0;
        haveNeededQuantity1 = false;
        haveNeededQuantity2 = false;
        haveNeededQuantity3 = false;
        haveNeededQuantity4 = false;

        for(int x = 0; x<equipment.listOwnedItem.Count; x++)
        {
            if(equipment.listOwnedItem[x].id == id1)
            {
                haveId1 = true;
                itemCounter = itemCounter + equipment.listOwnedItem[x].stackedQuantity;
                if(itemCounter >= count1)
                {
                    haveNeededQuantity1 = true;
                }
               
            }
            if(equipment.listOwnedItem[x].id == id2)
            {
                itemCounter = 0;
                haveId2 = true;
                itemCounter = itemCounter + equipment.listOwnedItem[x].stackedQuantity;
                if (itemCounter >= count2)
                {
                    haveNeededQuantity2 = true;
                }
                
            }
            if (equipment.listOwnedItem[x].id == id3)
            {
                itemCounter = 0;
                haveId3 = true;
                itemCounter = itemCounter + equipment.listOwnedItem[x].stackedQuantity;

                if (itemCounter >= count3)
                {
                    haveNeededQuantity3 = true;
                }
                
            }
            if (equipment.listOwnedItem[x].id == id4)
            {
                haveId4 = true;
                itemCounter = itemCounter + equipment.listOwnedItem[x].stackedQuantity;
                if (itemCounter >= count4)
                {
                    haveNeededQuantity4 = true;
                }

            }

        }
        if (haveId1 == true && haveId2 == true && haveId3 == true && haveId4 == true && haveNeededQuantity1 == true && haveNeededQuantity2 == true 
            && haveNeededQuantity3 == true && haveNeededQuantity4 == true)
        {
            canCraft = true;
        }
    }
    void addItem(int idItem)
    {
        if (didStacked == true)
        {
            for (int i = 0; i < equipment.listOwnedItem.Count; i++)
            {
                if (idItem == equipment.listOwnedItem[i].id && equipment.listOwnedItem[i].stackedQuantity < maxStack)
                {
                    equipment.listOwnedItem[i].stackedQuantity += 1;
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
                if (equipment.listOwnedItem[i].id == 0)
                {
                    equipment.listOwnedItem[i] = new Object(Database.itemList[idItem].id, Database.itemList[idItem].name, Database.itemList[idItem].description, Database.itemList[idItem].isWeapon, Database.itemList[idItem].stackedQuantity);
                    didStacked = true;
                    break;
                }
            }
        }
    }
}
 