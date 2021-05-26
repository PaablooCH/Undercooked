using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsChef : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Relax()
    {
        anim.SetTrigger("Idle");
    }

    public void Move()
    {
        anim.SetTrigger("Move");
    }

    public void Cut()
    {
        anim.SetTrigger("Cut");
    }

    public void PutFood()
    {
        anim.SetTrigger("PutFood");
    }
}
