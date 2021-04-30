using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveFood : MonoBehaviour
{
    public Transform Dest;
    bool onTable;
    GameObject food;
    float cont;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 1)
            {
                onTable = false;
                food = null;
                cont = 0;
            }
            //Debug.Log("Soy Player");
        }
        else if (obj.tag == "Food")
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                //obj.GetComponent<BoxCollider>().enabled = true;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.transform.position = Dest.position;
                obj.transform.parent = GameObject.Find("Leave").transform;
                onTable = true;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                food = obj.gameObject;
                cont = 0;
            }
            //Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }
}
