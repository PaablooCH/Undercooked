using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateFoodPosition : MonoBehaviour
{

    bool pick;
    public Transform Dest;
    // Start is called before the first frame update
    void Start()
    {
        pick = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(pick) this.transform.position = Dest.position;
    }

    public void changeState()
    {
        if (pick) pick = false;
        else pick = true;
    }
}
