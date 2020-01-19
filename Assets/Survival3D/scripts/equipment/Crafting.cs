using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public Database Database;
    public equipment equipment;
    public GUISkin skin;
    int numberSocketsX;
    int numberSocketsY;
    static public bool didViewCrafting;
    public string info;
    bool haveId1;
    bool haveId2;
    bool haveId3;
    bool canCraft;
    private float timeCraftingItem;
    void Start()
    {
        numberSocketsX = 5;
        numberSocketsY = 4;
        info = null;
        
    }


    void Update()
    {   
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

                if (slotLocation.Contains(Event.current.mousePosition) && Input.GetMouseButtonUp(0) && timeCraftingItem + 1 < DayNightCycle.actualTime)
                {
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
            info = "Needed items:" + "\n" + "bottle";
        }
        if (id == 1) // axe
        {
            info = "Needed items:" + "\n" + "stone" + "\n" + "wood";
        }

    }
    // dla kazdego przedmiotu z database z craftingu musimy tutaj wpisac info id musi sie zgadzac
    void CreateItem(int id)
    {
        if(id == 3)
        {
            CheckItem(2);
            if (canCraft == true)
            {
                Debug.Log("Mozemy craftowac");
            }
        }
    }

    void CheckItem(int id1, int id2 =0, int id3 =0) //tyle zmiennych ile id w craftingu database
    {
        canCraft = false;

        for(int x = 0; x<equipment.listOwnedItem.Count; x++)
        {
            if(equipment.listOwnedItem[x].id == id1)
            {
                haveId1 = true;
            }
            if(equipment.listOwnedItem[x].id == id2)
            {
                haveId2 = true;
            }
            if (equipment.listOwnedItem[x].id == id3)
            {
                haveId3 = true;
            }
        }
        if (haveId1 == true && haveId2 == true && haveId3 == true)
        {
            canCraft = true;
        }
    }
}
 