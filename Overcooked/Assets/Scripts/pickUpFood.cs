using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpFood : MonoBehaviour
{
    private bool holded;
    private float cont = 1;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        holded = false;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        //Debug.Log(cont);
    }

    private void OnTriggerStay(Collider obj)
    {
        if (obj.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space) && !holded && cont >= 1 && !obj.gameObject.GetComponent<MoveCharacter>().checkHold())
            {
                this.GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = obj.transform.GetChild(6).position;
                this.transform.parent = GameObject.Find("ToPickUp").transform;
                holded = true;
                obj.gameObject.GetComponent<MoveCharacter>().changeHold(true);
                obj.gameObject.GetComponent<MoveCharacter>().holdFood(this.gameObject);
                if (this.tag == "Extinguisher") this.GetComponent<BoxCollider>().enabled = false;
                player = obj.gameObject;
                Debug.Log("Holisss");
            }
            //Debug.Log("Soy Player");
        }
    }

    public void changeState()
    {
        holded = false;
    }

    public void resetCont()
    {
        cont = 0;
    }
    public void emptyPlayer()
    {
         player.gameObject.GetComponent<MoveCharacter>().changeHold(false);
         player.gameObject.GetComponent<MoveCharacter>().leaveFood();
         player = null;
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }
}
