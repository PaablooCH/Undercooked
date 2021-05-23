using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodKeys : MonoBehaviour
{
    private bool canBurned;
    // Start is called before the first frame update
    void Start()
    {
        canBurned = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.B)) {
            canBurned = !canBurned;
        }
       else if (Input.GetKey(KeyCode.F))
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("toolBlender");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<blendingBlender>().finishProcess();
            }
            objects = GameObject.FindGameObjectsWithTag("toolOven");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<cookingOven>().finishProcess();
            }
            objects = GameObject.FindGameObjectsWithTag("toolPan");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<cookingPan>().finishProcess();
            }
            objects = GameObject.FindGameObjectsWithTag("toolCutting");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<SliceFood>().finishProcess();
            }
        }
    }

    public bool getBurned()
    {
        return canBurned;
    }
}
