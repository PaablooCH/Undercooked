using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 3.0f;
    //bool holding = false;
    public Transform Dest;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0.0f, 0.0f, -speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

}
