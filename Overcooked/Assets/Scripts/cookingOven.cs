using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookingOven : MonoBehaviour
{
    private ParticleSystem ps;
    private bool onOven;
    private GameObject food;
    private float cont;
    private bool cooked;
    private bool burned;
    public Slider progress;
    public Image danger;
    public float dangerCount;

    // Start is called before the first frame update
    void Start()
    {
        onOven = false;
        cont = 0;
        dangerCount = 0;
        cooked = false;
        burned = false;
        ps = transform.Find("effects").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if (cooked) dangerCount += Time.deltaTime;
        if (food != null)
        {
            if (cooked && dangerCount >= 2.0f && danger.gameObject.active == false) danger.gameObject.active = true;
            if (food.name != "Burned" && cont >= food.GetComponent<convertInTo>().getCountNext() && cooked)
            {
                //Debug.Log("jida");
                burned = true;
                GameObject a = food.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = transform.GetChild(0).position;
                food.transform.parent = transform.GetChild(0).transform;
                food.GetComponent<pickUpFood>().changeState();
                food.GetComponent<pickUpFood>().resetCont();
                food.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                var main = ps.main;
                main.startColor = new Color(0.2078431f, 0.1882353f, 0.1882353f, 1);
                main.startLifetime = 10;
                var emission = ps.emission;
                emission.rateOverTime = 100;
            }
            else if (!cooked && cont >= food.GetComponent<convertInTo>().getCountNext())
            {
                cooked = true;
                GameObject a = food.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = transform.GetChild(0).position;
                food.transform.parent = transform.GetChild(0).transform;
                food.GetComponent<pickUpFood>().changeState();
                food.GetComponent<pickUpFood>().resetCont();
                food.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                cont = 0;
                progress.gameObject.active = false;
            }
            //Debug.Log(cont + food.name);
        }


    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player" && !burned)
        {
            if (Input.GetKey(KeyCode.Space) && onOven && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.transform.position = obj.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = obj.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                onOven = false;
                food = null;
                cont = 0;
                cooked = false;
                var main = ps.main;
                main.startColor = new Color(0.5471698f, 0.5471698f, 0.5471698f, 1);
                main.startLifetime = 1.5f;
                var emission = ps.emission;
                emission.rateOverTime = 15;
                ps.Stop();
                danger.gameObject.active = false;
            }
            // Debug.Log("Soy Player");
        }
        else if (obj.tag == "Oven")
        {
            if (Input.GetKey(KeyCode.Space) && !onOven && cont >= 2)
            {

                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = transform.GetChild(0).position;
                obj.transform.eulerAngles = transform.GetChild(0).eulerAngles;
                obj.transform.parent = transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                onOven = true;
                food = obj.gameObject;
                cont = 0;
                ps.Play();
                progress.gameObject.active = true;
                progress.GetComponent<progressBar>().StartCounter(food.gameObject.GetComponent<convertInTo>().getCountNext());
            }
            Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onOven) onOven = false;
        else onOven = true;
    }

    /*public void extinguish()
    {
        if (burned)
        {
            burned = false;
            ps.Stop();
        }
    }*/
    private void OnParticleCollision(GameObject other)
    {
        if (burned)
        {
            burned = false;
            ps.Stop();
        }
    }
}
