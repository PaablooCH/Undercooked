using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateFood: MonoBehaviour
{
    public GameObject food;
    private float cont;
    private bool full;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = (GameObject) Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
        obj.transform.parent = transform;
        full = true;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        //Debug.Log(foodGenerated.gameObject); 
        if (!full && cont >= 5)
        {
            GameObject obj = (GameObject)Instantiate(food, transform.position + new Vector3(-0.05f, 0.4f, 0.0f), food.transform.rotation);
            obj.transform.parent = transform;
            obj.GetComponent<pickUpFood>().enabled = true;
            cont = 0;
            full = true;
        }
    }

    private void OnCollisionStay(Collision obj)
    {
        if (Input.GetKey(KeyCode.Space) && full)
        {
            if (obj.collider.tag == "Player")
            {
                Debug.Log("hola");
                full = false;
                cont = 0;
            }
        }
    }

}