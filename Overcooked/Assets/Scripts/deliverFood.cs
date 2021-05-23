using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverFood : MonoBehaviour
{

    private float cont = 0;
    private GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
    }

    private void OnTriggerStay(Collider obj)
    {
        if ( obj.tag == "Complete")
        {
            if (Input.GetKey(KeyCode.Space) && cont >= 0.7)
            {
                if (gameManager.Instance.checkRecipe(obj.gameObject))
                {
                    gameManager.Instance.nextRecipe();
                    obj.gameObject.GetComponent<pickUpFood>().emptyPlayer();
                    obj.gameObject.GetComponent<pickUpFood>().changeState();
                    obj.gameObject.GetComponent<pickUpFood>().resetCont();
                    Destroy(obj.gameObject);
                }
                cont = 0;
            }
        }
    }
}
