using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFood : MonoBehaviour
{
    GameObject food;
    float cont;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Food" || obj.tag == "Cutted" || obj.tag == "Cooked" || obj.tag == "Blended" || obj.tag == "Complete" || obj.tag == "Combination")
        {
            if (Input.GetKey(KeyCode.Space) && cont >= 2)
            {
                Destroy(obj.gameObject);
                cont = 0;
            }
            //Debug.Log("Soy Comida");
        }
    }

}
