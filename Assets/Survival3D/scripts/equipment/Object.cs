using System.Collections;

using UnityEngine;
[System.Serializable]

public class Object
{
    public int id;
    public string name;
    public string description;
    public Texture2D objectIcons;


    public Object()
    {

    }

    public Object(int Id, string Name, string Description)
    {
        id = Id;
        name = Name;
        description = Description;
        objectIcons = Resources.Load<Texture2D>("Icons/" + name);
    } 

}
