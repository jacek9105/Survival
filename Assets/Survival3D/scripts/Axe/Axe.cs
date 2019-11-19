using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animation anim;
    public bool hitAble;
    public bool hited;

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
            collider.gameObject.GetComponent<Tree_Felling>().TreeHP -= 1;
        }
    }

}
