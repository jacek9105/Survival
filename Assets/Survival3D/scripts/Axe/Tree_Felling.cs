using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Felling : MonoBehaviour
{

    public int TreeHP;
    public Rigidbody rigidBody;
    public Transform trunk; //new 
    public GameObject tree;
    void Start()
    {
        tree = this.gameObject; //new
        rigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TreeHP <= 0)
        {
            rigidBody.isKinematic = false;
            TreeDestroy(); // new
        }
        /*
            if(TreeHP == -2)
        {
            Destroy(gameObject);
        }
        */

    }
    void TreeDestroy()  //new 
    {
        Destroy(gameObject);
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(trunk, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        Instantiate(trunk, tree.transform.position + new Vector3(2, 0, 0) + position, Quaternion.identity);
        Instantiate(trunk, tree.transform.position + new Vector3(4, 0, 0) + position, Quaternion.identity);
    }

}
