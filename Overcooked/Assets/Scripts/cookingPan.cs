using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookingPan : MonoBehaviour
{
    private ParticleSystem ps;
    private bool onPan;
    private GameObject food;
    private float cont;
    private bool cooked;
    private bool burned;
    private GameObject tapa;
    public Slider progress;
    public Image danger;
    public float dangerCount;
    private GodKeys godKeys;

    // Start is called before the first frame update
    void Start()
    {
        onPan = false;
        cont = 0;
        dangerCount = 0;
        cooked = false;
        burned = false;
        ps = transform.Find("effects").GetComponent<ParticleSystem>();
        tapa = transform.Find("tapa").gameObject;
        godKeys = GameObject.FindWithTag("Player").GetComponent<GodKeys>();
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if (cooked) dangerCount += Time.deltaTime;
        if(food != null)
        {
            food.SetActive(false);
            if (cooked && dangerCount >= 2.0f && !danger.gameObject.activeInHierarchy)
            {
                danger.gameObject.SetActive(true);
                gameSounds.Instance.playDangerSound();
            }
            if (food.tag != "Complete" && cont >= food.GetComponent<convertInTo>().getCountNext() && cooked && godKeys.getBurned())
            {
                burned = true;
                GameObject a = food.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.GetComponent<pickUpFood>().changeState();
                food.GetComponent<pickUpFood>().resetCont();
                food.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                var main = ps.main;
                main.startColor = new Color(0.2078431f, 0.1882353f, 0.1882353f, 1);
                main.startLifetime = 3;
                var emission = ps.emission;
                emission.rateOverTime = 100;
            }
            else if (!cooked &&  cont >= food.GetComponent<convertInTo>().getCountNext())
            {
                cooked = true;
                GameObject a = food.GetComponent<convertInTo>().convertFood();
                Destroy(food);
                food = a;
                food.transform.position = this.transform.GetChild(0).position;
                food.transform.parent = this.transform.GetChild(0).transform;
                food.GetComponent<pickUpFood>().changeState();
                food.GetComponent<pickUpFood>().resetCont();
                food.GetComponent<pickUpFood>().enabled = false;
                food.GetComponent<Rigidbody>().useGravity = false;
                cont = 0;
                progress.gameObject.SetActive(false);
            }
        }
        

    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player" && !burned)
        {
            if (Input.GetKey(KeyCode.Space) && onPan && cont >= 0.5 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                food.SetActive(true);
                food.transform.position = obj.transform.Find("ToPickUp").position;
                food.transform.eulerAngles = obj.transform.Find("ToPickUp").eulerAngles;
                food.transform.parent = obj.transform.Find("ToPickUp").transform;
                food.GetComponent<pickUpFood>().enabled = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(food);
                food.gameObject.GetComponent<pickUpFood>().setPlayer(obj.gameObject);
                onPan = false;
                food = null;
                cont = 0;
                dangerCount = 0;
                cooked = false; 
                var main = ps.main;
                main.startColor = new Color(0.5471698f, 0.5471698f, 0.5471698f, 1);
                main.startLifetime = 1.5f;
                var emission = ps.emission;
                emission.rateOverTime = 30;
                ps.Stop();
                tapa.SetActive(false);
                danger.gameObject.SetActive(false);
                gameSounds.Instance.stopPanSound();
                gameSounds.Instance.stopDangerSound();

            }
            
        }
        else if (obj.tag == "Cutted" && obj.gameObject.GetComponent<convertInTo>().nextFood != null)
        {
            if (Input.GetKey(KeyCode.Space) && !onPan && cont >= 2 )
            {

                obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                obj.transform.position = this.transform.GetChild(0).position;
                obj.transform.eulerAngles = this.transform.GetChild(0).eulerAngles;
                obj.transform.parent = this.transform.GetChild(0).transform;
                obj.gameObject.GetComponent<pickUpFood>().changeState();
                obj.gameObject.GetComponent<pickUpFood>().resetCont();
                obj.gameObject.GetComponent<pickUpFood>().enabled = false;
                onPan = true;
                food = obj.gameObject;
                cont = 0;
                ps.Play();
                tapa.SetActive(true);
                progress.gameObject.SetActive(true);
                progress.GetComponent<progressBar>().StartCounter(food.gameObject.GetComponent<convertInTo>().getCountNext());
                gameSounds.Instance.playPanSound();
            }
        }
    }

    public void changeState()
    {
        if (onPan) onPan = false;
        else onPan = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (burned)
        {
            burned = false;
            ps.Stop();
        }
    }

    public void finishProcess()
    {
        if (food != null)
        {
            cont = food.GetComponent<convertInTo>().getCountNext() - 0.05f;
        }
    }
}