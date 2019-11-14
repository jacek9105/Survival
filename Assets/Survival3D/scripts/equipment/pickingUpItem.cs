using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUpItem : MonoBehaviour
{
    public GameObject itemToPick;
    public GUISkin skin;
    bool canLift;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canLift == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(itemToPick);
                itemToPick = null;
            }
        }
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("itemToPick"))
        {
            itemToPick = col.gameObject;
            canLift = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("itemToPick"))
        {
            itemToPick = null;
            canLift = false;
        }
    }

    private void OnGUI()
    {
        if (canLift == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 200), "Push e to lift item", skin.GetStyle("Lift"));
        }
    }
}
