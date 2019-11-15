using System.Collections;

using UnityEngine;
[System.Serializable]

public class Object
{
    public int id;
    public string name;
    public string description;

    public Object()
    {

    }

    public Object(int Id, string Name, string Description)
    {
        id = Id;
        name = Name;
        description = Description;
    }

}
