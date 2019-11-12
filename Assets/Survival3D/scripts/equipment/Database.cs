using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public List<Object> itemList = new List<Object> ();


    void Awake()
    {
        itemList.Add(new Object(0, "Siekiera", "Siekiera bez krwi"));


    }
}
