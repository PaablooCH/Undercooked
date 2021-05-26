using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsBlender : MonoBehaviour
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

    public void Idle()
    {
        anim.SetTrigger("idle");
    }

    public void Shake()
    {
        anim.SetTrigger("shake");
    }
}
