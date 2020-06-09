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
        itemList.Add(new Object(5, "meat", "Mięso dla życia", false, 1));
        itemList.Add(new Object(6, "knife", "Nóż", true, 1));
        itemList.Add(new Object(7, "rope", "Pień do budowy tratwy", false, 1));
        itemList.Add(new Object(8, "fak", "Apteczka - +25 HP", false, 1));
        itemList.Add(new Object(9, "can", "Konserwa - +30 Głodu", false, 1));
        itemList.Add(new Object(10, "rescueboat", "Tratwa - niesbędna do opuszczenia wyspy", false, 1));
        itemList.Add(new Object(11, "sail", "Żagiel do budowy Tratwy", false, 1));
        itemList.Add(new Object(12, "waterbottle", "Butelka z wodą", false, 1));
        itemList.Add(new Object(13, "mushroom2", "Grzyb jadalny", false, 1));
        itemList.Add(new Object(14, "matches", "Zapałki", false, 1));
        itemList.Add(new Object(15, "torch", "Pochodnia", false, 1));


        // nulle albo cos dodajemy albo wyrzucamy musi byc tyle samo pozycji ile jest miejsca w numbersocket w skrypcie crafting
        itemCraftingList.Add(new Object(1, "axe", "Siekiera bez krwi", true, 1));
        itemCraftingList.Add(new Object(3, "bottle", "Butelka z wodą", false, 1));
        itemCraftingList.Add(new Object(10, "rescueboat", "Tratwa", false, 1));
        itemCraftingList.Add(new Object(8, "fak", "Apteczka - +25 HP", false, 1));
        itemCraftingList.Add(new Object(15, "torch", "Pochodnia", false, 1));
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
