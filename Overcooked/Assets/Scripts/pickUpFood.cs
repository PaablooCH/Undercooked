using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpFood : MonoBehaviour
{
    public Transform Dest;
    bool holded;
    float cont = 1;
    // Start is called before the first frame update
    void Start()
    {
        holded = false;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        //Debug.Log(cont);
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && !holded && cont >= 1)
            {
                //this.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = Dest.position;
                this.transform.parent = GameObject.Find("ToPickUp").transform;
                holded = true;
                //this.GetComponent<LeaveFood>().changeState();
            }
            //Debug.Log("Soy Player");
        }
    }

    public void changeState()
    {
        if (holded) holded = false;
        else holded = true;
    }

    public void resetCont()
    {
        cont = 0;
    }
}
