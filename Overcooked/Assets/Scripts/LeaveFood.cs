using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFood : MonoBehaviour
{
    public Transform Dest;
    bool onTable;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if(obj.tag == "Furniture")
        {
            if (Input.GetKey(KeyCode.Space) && !onTable)
            {
                this.GetComponent<BoxCollider>().enabled = true;
                this.GetComponent<Rigidbody>().useGravity = true;
                this.transform.position = Dest.position;
                this.transform.parent = GameObject.Find("Leave").transform;
                onTable = true;
                //this.GetComponent<pickUpFood>().changeState();
            }
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}
