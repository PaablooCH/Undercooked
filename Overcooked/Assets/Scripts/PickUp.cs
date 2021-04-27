using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform Dest;

    bool holding;

    void Start()
    {
        holding = false;
    }

    void Update()
    {

    }


    /*void onTriggerEnter(Collider obj)
    {
        
        if (Input.GetKey(KeyCode.Space) && !holding) {
            obj.GetComponent<BoxCollider>().enabled = false;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.transform.position = Dest.position;
            obj.transform.parent = GameObject.Find("ToPickUp").transform;
            holding = true;
        }

       if(Input.GetKey(KeyCode.Space) && holding)
        {
            obj.GetComponent<BoxCollider>().enabled = true;
            obj.transform.parent = null;
            obj.GetComponent<Rigidbody>().useGravity = true;
            holding = false;
        }
        Destroy(obj.gameObject);
    }*/

    /*
    void onMouseDown() 
    { 
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = Dest.position;
        this.transform.parent = GameObject.Find("arms").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }*/

}
