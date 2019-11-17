using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Object> itemList = new List<Object> ();


    void Awake()
    {
        itemList.Add(new Object(0, "null", "null"));
        itemList.Add(new Object(0, "Siekiera", "Siekiera bez krwi"));


    }
}
