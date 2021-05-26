using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blendingBlender : MonoBehaviour
{
    private bool onTable;
    private GameObject food;
    private float cont;
    private bool finish;
    public Slider progress;
    private GameObject tapa;
    private animationsBlender anim;

    // Start is called before the first frame update
    void Start()
    {
        onTable = false;
        cont = 0;
        finish = false;
        tapa = transform.Find("Tapa").gameObject;
        anim = GetComponent<animationsBlender>();
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;

        if (food != null)
        {
            if (!finish && cont >= food.gameObject.GetComponent<convertInTo>().getCountBlend())
            {
                finish = true;
                anim.Idle();
                GameObject a = food.GetComponent<convertInTo>().convertBlendfood();
                Destroy(food);
                food = a;
                food.SetActive(false);
                food.transform.position = this.transform.Find("Child").position;
                food.transform.parent = this.transform.Find("Child").transform;
                food.GetComponent<pickUpFood>().changeState();
                food.GetComponent<pickUpFood>().resetCont();
                food.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                progress.gameObject.SetActive(false);
                gameSounds.Instance.playBlenderEndSound();
            }
        }
            
        
        //Debug.Log(cont + food.name);
        
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && onTable && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.SetActive(true);
                tapa.SetActive(false);
                food.transform.position = obj.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = obj.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                onTable = false;
                food = null;
                cont = 0;
                finish = false;
            }
            //Debug.Log("Soy Player");
        }
        else if (obj.tag == "Cutted" && obj.gameObject.GetComponent<convertInTo>().blendFood != null)
        {
            if (Input.GetKey(KeyCode.Space) && !onTable && cont >= 2)
            {
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = this.transform.Find("Child").position;
                obj.transform.eulerAngles = this.transform.Find("Child").eulerAngles;
                obj.transform.parent = this.transform.Find("Child").transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                onTable = true;
                food = obj.gameObject;            
                cont = 0;
                tapa.SetActive(true);
                anim.Shake();
                food.SetActive(false);
                progress.gameObject.SetActive(true);
                progress.GetComponent<progressBar>().StartCounter(food.gameObject.GetComponent<convertInTo>().getCountBlend());
                gameSounds.Instance.playBlenderSound();
            }
            // Debug.Log("Soy Comida");
        }
    }

    public void changeState()
    {
        if (onTable) onTable = false;
        else onTable = true;
    }

    public void finishProcess()
    {
        if (food != null)
        {
            cont = food.GetComponent<convertInTo>().getCountBlend();
        }
    }

}
