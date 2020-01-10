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
        itemList.Add(new Object(3, "bottle", "Butelka z wodą",false,1));

        // nulle albo cos dodajemy albo wyrzucamy musi byc tyle samo pozycji ile jest miejsca w numbersocket w skrypcie crafting
        itemCraftingList.Add(new Object(1, "axe", "Siekiera bez krwi", true, 1));
        itemCraftingList.Add(new Object(3, "bottle", "Butelka z wodą", false, 1));
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
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));
        itemCraftingList.Add(new Object(0, "null", "null", false, 1));

    }
}
