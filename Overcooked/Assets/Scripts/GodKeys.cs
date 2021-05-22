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
    }

    public bool getBurned()
    {
        return canBurned;
    }
}
