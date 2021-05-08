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
    public GameObject combineWithCheese()
    {
        if (Cheese == null) return null;
        GameObject a = Instantiate(Cheese, this.transform.position, Cheese.transform.rotation);
        return a;
    }
    public GameObject combineWithTomato()
    {
        if (Tomato == null) return null;
        GameObject a = Instantiate(Tomato, this.transform.position, Tomato.transform.rotation);
        return a;
    }
    public GameObject combineWithCucumber()
    {
        if (Cucumber == null) return null;
        GameObject a = Instantiate(Cucumber, this.transform.position, Cucumber.transform.rotation);
        return a;
    }
    public GameObject combineWithBread()
    {
        if (Bread == null) return null;
        GameObject a = Instantiate(Bread, this.transform.position, Bread.transform.rotation);
        return a;
    }
    public GameObject combineWithFish()
    {
        if (Fish == null) return null;
        GameObject a = Instantiate(Fish, this.transform.position, Fish.transform.rotation);
        return a;
    }
    public GameObject combineWithPotato()
    {
        if (Potato == null) return null;
        GameObject a = Instantiate(Potato, this.transform.position, Potato.transform.rotation);
        return a;
    }
    public GameObject combineWithMeat()
    {
        if (Meat == null) return null;
        GameObject a = Instantiate(Meat, this.transform.position, Meat.transform.rotation);
        return a;
    }
}
