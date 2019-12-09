using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickingUpItem : MonoBehaviour
{
    public GameObject itemToPick;
    public GUISkin skin;
    bool canLift;

    int idItem;

    public equipment equipment;
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
                idItem = itemToPick.GetComponent<itemToLift>().id;

                  for (int i = 0; i < equipment.listOwnedItem.Count; i++)
                    {
                        if (idItem == equipment.listOwnedItem[i].id && itemToPick != null)
                        {
                            Destroy(itemToPick);
                            itemToPick = null;
                            
                        }
                       
                                

                   
                    
                        if (equipment.listOwnedItem[i].id == 0 && itemToPick != null)
                        {
                            equipment.listOwnedItem[i] = Database.itemList[idItem];
                            Destroy(itemToPick);
                            itemToPick = null;
                            
                        }
                       
                    }
                

            }
                canLift = false;
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
