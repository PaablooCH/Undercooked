using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceFood : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Dest;
    public Transform Player;
    private GameObject food;
    private float cont;
    private bool full;
    public GameObject meat;
    public GameObject cucumber;
    public GameObject bread;
    public GameObject tomato;
    public GameObject fish;
    public GameObject potato;
    public GameObject cheese;


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
        if (cont >= 3 && full)
        {
            if (food.name == "meat")
            {
                Destroy(food);
                food = (GameObject)Instantiate(meat, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), meat.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "cucumber")
            {
                Destroy(food);
                food = (GameObject)Instantiate(cucumber, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), cucumber.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "bread")
            {
                Destroy(food);
                food = (GameObject)Instantiate(bread, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), bread.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "tomato3.0")
            {
                Destroy(food);
                food = (GameObject)Instantiate(tomato, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), tomato.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "fish")
            {
                Destroy(food);
                food = (GameObject)Instantiate(fish, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), fish.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "potato")
            {
                Destroy(food);
                food = (GameObject)Instantiate(potato, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), potato.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
            if (food.name == "cheese")
            {
                Destroy(food);
                food = (GameObject)Instantiate(cheese, transform.position + new Vector3(-0.06f, 0.5f, 0.05f), cheese.transform.rotation);
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.gameObject.GetComponent<pickUpFood>().changeState();
                food.gameObject.GetComponent<pickUpFood>().resetCont();
            }
        }
        Debug.Log(food);
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
