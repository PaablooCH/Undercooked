using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Dest;
    public Transform Player;
    GameObject food;
    float cont;
    bool full;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        full = false;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if(cont >= 3 && full)
        {
            GameObject obj = (GameObject)Instantiate(GameObject.Find("Sliced" + food.name), Dest.position, food.transform.rotation);
            obj.transform.parent = GameObject.Find("Leave").transform;
            Destroy(food.gameObject);
            food = null;
        }
    }

    private void OnTriggerStay(Collider obj)
    {
        if(obj.tag == "Food")
        {
            if (Input.GetKey(KeyCode.Space) && !full)
            {
                //obj.GetComponent<BoxCollider>().enabled = true;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.transform.position = Dest.position;
                obj.transform.parent = GameObject.Find("Leave").transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                food = obj.gameObject;
                cont = 0;
                full = true;
            }
        }
    }

    public void noFull()
    {
        full = false;
    }
}
