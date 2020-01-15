using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAxe : MonoBehaviour
{
    //  public Animation anim;
    public bool hitAble;
    public bool hited;
    //public AudioSource chopSound;
    public equipment eq;

    void Start()
    {
        hitAble = true;

    }

    // Update is called once per frame
    void Update()
    {
        /*

        if (Input.GetMouseButtonDown(0) && hitAble == true)
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
         */
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Enemy")
        {
            if (collider.gameObject.GetComponent<pigHP>().pigHealtPoints >= 0)
            {
                collider.gameObject.GetComponent<pigHP>().pigHealtPoints -= 1;
            }
        }
    }

}
