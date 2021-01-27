using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princess_anim : MonoBehaviour
{
    // Update is called once per frame
    public Animator vict_anim;
    private void Awake()
    {
        vict_anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        victory();
    }
    public void victory()
    {
        vict_anim.SetTrigger("victory");
    }
}
