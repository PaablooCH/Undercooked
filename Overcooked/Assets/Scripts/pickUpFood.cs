using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpFood : MonoBehaviour
{
    public Transform Dest;
    bool holded;
    // Start is called before the first frame update
    void Start()
    {
        holded = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && !holded)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = Dest.position;
                this.transform.parent = GameObject.Find("ToPickUp").transform;
                holded = true;
                //this.GetComponent<LeaveFood>().changeState();
            }
        }
    }

    public void changeState()
    {
        if (holded) holded = false;
        else holded = true;
    }
}
