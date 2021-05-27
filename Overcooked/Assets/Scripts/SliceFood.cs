using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliceFood : MonoBehaviour
{
    public Transform Player;
    private GameObject food;
    private float cont;
    private bool full;
    private ParticleSystem ps;
    public Slider progress;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        full = false;
        ps = transform.GetComponent<ParticleSystem>();
        progress.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if (food != null && cont >= food.gameObject.GetComponent<convertInTo>().getCountNext() && full && food.tag == "Food")
        {
            GameObject a = food.gameObject.GetComponent<convertInTo>().convertFood();
            Destroy(food);
            food = a;
            food.transform.position = this.transform.GetChild(0).position;
            food.transform.parent = this.transform.GetChild(0).transform;
            food.gameObject.GetComponent<pickUpFood>().changeState();
            food.gameObject.GetComponent<pickUpFood>().resetCont();
            food.gameObject.GetComponent<pickUpFood>().enabled = false;
            food.GetComponent<Rigidbody>().useGravity = false;
            GameObject.FindWithTag("Player").GetComponent<animationsChef>().Relax();
            GameObject knife = GameObject.FindWithTag("Player").GetComponent<MoveCharacter>().leaveObjectHand();
            knife.transform.parent = this.transform;
            knife.transform.localEulerAngles = this.transform.localEulerAngles;
            knife.transform.position = this.transform.position + new Vector3(-0.25f, 0.7f, 0.1f);
            GameObject.FindWithTag("Player").gameObject.GetComponent<MoveCharacter>().enabled = true;
            ps.Stop();
            progress.gameObject.SetActive(false);
            gameSounds.Instance.stopKnifeSound();
        }
        //Debug.Log(food);
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Food")
        {
            if (Input.GetKey(KeyCode.Space) && !full && cont >= 0.5)
             {
                //obj.GetComponent<BoxCollider>().enabled = true;
                //obj.GetComponent<Rigidbody>().useGravity = true;
                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                GameObject.FindWithTag("Player").GetComponent<MoveCharacter>().objectHand(transform.Find("Knife(Clone)").gameObject);
                GameObject.FindWithTag("Player").GetComponent<animationsChef>().Relax();
                GameObject.FindWithTag("Player").GetComponent<animationsChef>().Cut();
                GameObject.FindWithTag("Player").GetComponent<MoveCharacter>().enabled = false;
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.eulerAngles = this.transform.GetChild(0).eulerAngles;
                obj.transform.parent = this.transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                food = obj.gameObject;
                cont = 0;
                full = true;
                ps.Play();
                progress.gameObject.SetActive(true);
                progress.GetComponent<progressBar>().StartCounter(food.gameObject.GetComponent<convertInTo>().getCountNext());
                gameSounds.Instance.playKnifeSound();
            }
        }
        else if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && full && cont >= 1 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.transform.position = obj.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = obj.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
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

    public void finishProcess()
    {
        if (food != null)
        {
            cont = food.GetComponent<convertInTo>().getCountNext();
        }
    }
}
