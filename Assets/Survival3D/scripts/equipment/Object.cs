using System.Collections;

using UnityEngine;
[System.Serializable]

public class Object
{
    public int id;
    public string name;
    public string description;
    public Texture2D objectIcons;
    public GameObject prefabObject;
    public int quantityInStack;
    public bool isWeapon;


    public Object()
    {

    }

    public Object(int Id, string Name, string Description, bool IsWeapon, int QuantityInStack)
    {
        quantityInStack = QuantityInStack;
        id = Id;
        name = Name;
        description = Description;
        isWeapon = IsWeapon;
        objectIcons = Resources.Load<Texture2D>("Icons/" + name);
        prefabObject = Resources.Load<GameObject>("Prefabs/" + name);
    } 

}
