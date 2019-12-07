using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animation anim;
    public bool hitAble;
    public bool hited;
    public AudioSource chopSound;
    public equipment eq;

    void Start()
    {
        hitAble = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && hitAble == true)
        {
            anim.Play();
        }

        if (anim.isPlaying == false)
        {
            hitAble = true;
            hited = false;
        }
        else
        {
            hitAble = false;
            hited = true;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Tree" && hited == true)
        {
            if(collider.gameObject.GetComponent<Tree_Felling>().TreeHP >0)
            { 
            collider.gameObject.GetComponent<Tree_Felling>().TreeHP -= 1;
                chopSound.Play();
            }
            if(collider.gameObject.GetComponent<Tree_Felling>().TreeHP == 0)
            {
                for(int i = 0; i<eq.listOwnedItem.Count; i++)
                {
                    if(eq.listOwnedItem[i].id == 0)
                    {
                        eq.listOwnedItem[i] = Database.itemList[2];
                        break;
                    }
                }
            }
        }
    }

}
