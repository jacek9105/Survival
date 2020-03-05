using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Object> itemList = new List<Object> ();

    public static List<Object> itemCraftingList = new List<Object>();
    void Awake()
    {
        itemList.Add(new Object(0, "null", "null", false,1));
        itemList.Add(new Object(1, "axe", "Siekiera bez krwi", true,1));
        itemList.Add(new Object(2, "trunk", "Pień do budowy", false,1));
        itemList.Add(new Object(3, "bottle", "Butelka z wodą gasi pragnienie",false,1));
        itemList.Add(new Object(4, "mushroom", "Muchomor. Odważysz się zjeść?", false, 1));
        itemList.Add(new Object(5, "meat", "Meal to health", false, 1));
        itemList.Add(new Object(6, "knife", "Weapon", true, 1));
        itemList.Add(new Object(7, "rope", "rope to build rescue boat", false, 1));
        itemList.Add(new Object(8, "fak", "First aid kit - +25 HP", false, 1));
        itemList.Add(new Object(9, "can", "Can of food - +30 Hungry", false, 1));
        itemList.Add(new Object(10, "rescueboat", "Needed to escape from island", false, 1));
        itemList.Add(new Object(11, "sail", "Needed to built rescue boat", false, 1));
        itemList.Add(new Object(12, "waterbottle", "Bottle of water", false, 1));
        itemList.Add(new Object(13, "mushroom2", "Grzyb jadalny", false, 1));
        itemList.Add(new Object(14, "matches", "Needed to ccraft torch", false, 1));
        itemList.Add(new Object(15, "torch", "Torch", false, 1));


        // nulle albo cos dodajemy albo wyrzucamy musi byc tyle samo pozycji ile jest miejsca w numbersocket w skrypcie crafting
        itemCraftingList.Add(new Object(1, "axe", "Siekiera bez krwi", true, 1));
        itemCraftingList.Add(new Object(3, "bottle", "Butelka z wodą", false, 1));
        itemCraftingList.Add(new Object(10, "rescueboat", "Rescue boat", false, 1));
        itemCraftingList.Add(new Object(8, "fak", "First aid kit - +25 HP", false, 1));
        itemCraftingList.Add(new Object(15, "torch", "Troch", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));

    }
}
