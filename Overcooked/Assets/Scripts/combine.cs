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
    public GameObject TomatoSauce;
    public GameObject CucumberSauce;
    public GameObject BreadPics;
    public GameObject CuttedBread;
    public GameObject CuttedFish;
    public GameObject CuttedPotato;
    public GameObject Dish;




    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject combineWithCheese()
    {
        if (Cheese == null) return null;
        GameObject a = Instantiate(Cheese, this.transform.position, Cheese.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithTomato()
    {
        if (Tomato == null) return null;
        GameObject a = Instantiate(Tomato, this.transform.position, Tomato.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithCucumber()
    {
        if (Cucumber == null) return null;
        GameObject a = Instantiate(Cucumber, this.transform.position, Cucumber.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithBread()
    {
        if (Bread == null) return null;
        GameObject a = Instantiate(Bread, this.transform.position, Bread.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithFish()
    {
        if (Fish == null) return null;
        GameObject a = Instantiate(Fish, this.transform.position, Fish.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithPotato()
    {
        if (Potato == null) return null;
        GameObject a = Instantiate(Potato, this.transform.position, Potato.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithMeat()
    {
        if (Meat == null) return null;
        GameObject a = Instantiate(Meat, this.transform.position, Meat.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithTomatoSauce()
    {
        if (TomatoSauce == null) return null;
        GameObject a = Instantiate(TomatoSauce, this.transform.position, TomatoSauce.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithCucumberSauce()
    {
        if (CucumberSauce == null) return null;
        GameObject a = Instantiate(CucumberSauce, this.transform.position, CucumberSauce.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithBreadPics()
    {
        if (BreadPics == null) return null;
        GameObject a = Instantiate(BreadPics, this.transform.position, BreadPics.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithCuttedBread()
    {
        if (CuttedBread == null) return null;
        GameObject a = Instantiate(CuttedBread, this.transform.position, CuttedBread.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithCuttedFish()
    {
        if (CuttedFish == null) return null;
        GameObject a = Instantiate(CuttedFish, this.transform.position, CuttedFish.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
    public GameObject combineWithCuttedPotato()
    {
        if (CuttedPotato == null) return null;
        GameObject a = Instantiate(CuttedPotato, this.transform.position, CuttedPotato.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }

    public GameObject combineWithDish()
    {
        if (Dish == null) return null;
        GameObject a = Instantiate(Dish, this.transform.position, Dish.transform.rotation);
        a.GetComponent<pickUpFood>().resetCont();
        return a;
    }
}
