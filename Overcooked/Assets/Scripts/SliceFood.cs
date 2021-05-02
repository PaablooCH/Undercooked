using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    public Transform Player;
    private GameObject food;
    private float cont;
    private bool full;

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
        if (cont >= 3 && full && food.tag == "Food")
        {
            GameObject a = food.gameObject.GetComponent<convertInTo>().convertFood();
            Destroy(food);
            food = a;
            food.transform.position = this.transform.GetChild(0).position;
            food.transform.parent = this.transform.GetChild(0).transform;
            food.gameObject.GetComponent<pickUpFood>().changeState();
            food.gameObject.GetComponent<pickUpFood>().resetCont();
        }
        //Debug.Log(food);
    }

    private void OnTriggerStay(Collider obj)
    {
         if (Input.GetKey(KeyCode.Space) && !full && cont >= 0.5)
            {
            if (obj.tag == "Food")
            {
                //obj.GetComponent<BoxCollider>().enabled = true;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.parent = this.transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                food = obj.gameObject;
                cont = 0;
                full = true;
            }
         }
        if (Input.GetKey(KeyCode.Space) && full && cont >= 1)
        {
            if (obj.tag == "Player")
            {
                food = null;
                full = false;
                cont = 0;
            }
        }

    }

    public void noFull()
    {
        full = false;
    }
}
