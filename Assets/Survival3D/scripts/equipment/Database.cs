﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Object> itemList = new List<Object> ();


    void Awake()
    {
        itemList.Add(new Object(0, "null", "null", false));
        itemList.Add(new Object(1, "axe", "Siekiera bez krwi", true));
        itemList.Add(new Object(2, "trunk", "Pień do budowy", false));
        itemList.Add(new Object(3, "bottle", "Butelka z wodą",false));


    }
}
