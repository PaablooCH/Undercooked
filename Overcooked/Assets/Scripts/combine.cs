using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combine : MonoBehaviour
{
    public GameObject Cheese;
    public GameObject Tomato;
    public GameObject Cucumber;
    public GameObject Bread;
    public GameObject Fish;
    public GameObject Meat;
    public GameObject Potato;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*private void OnTriggerStay(Collider obj)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(obj.tag == "Cutted" || obj.tag == "Blended")
            {
                if (this.name == "SlicedBread" && obj.name == "SlicedCheese") combineWithCheese();
                Debug.Log("Dentro de if");
            }
            Debug.Log("Pilla espacio");
        }
        Debug.Log("Se tocan");
    }*/

    // Update is called once per frame
    public GameObject combineWithCheese()
    {
        GameObject a = Instantiate(Cheese, this.transform.position, Cheese.transform.rotation);
        return a;
    }
    public GameObject combineWithTomato()
    {
        GameObject a = Instantiate(Tomato, this.transform.position, Tomato.transform.rotation);
        return a;
    }
    public GameObject combineWithCucumber()
    {
        GameObject a = Instantiate(Cucumber, this.transform.position, Cucumber.transform.rotation);
        return a;
    }
    public GameObject combineWithBread()
    {
        GameObject a = Instantiate(Bread, this.transform.position, Bread.transform.rotation);
        return a;
    }
    public GameObject combineWithFish()
    {
        GameObject a = Instantiate(Fish, this.transform.position, Fish.transform.rotation);
        return a;
    }
    public GameObject combineWithPotato()
    {
        GameObject a = Instantiate(Potato, this.transform.position, Potato.transform.rotation);
        return a;
    }
}
