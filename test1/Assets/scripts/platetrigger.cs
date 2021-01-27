using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platetrigger : MonoBehaviour
{
    public GameObject box;
    public SpriteRenderer plate;
    private bool inpos;
    // Start is called before the first frame update
    void Start()
    {
        plate.enabled = true;
        inpos = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="box")
        {
            plate.enabled = false;
            inpos = true;

        }
        if (col.gameObject.tag == "devil")
        {
            //lamp.SetActive(true);
            plate.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "devil" && inpos==false)
        {
            //lamp.SetActive(false);
            plate.enabled = true;

        }
        if (col.gameObject.tag == "box")
        {
            plate.enabled = true;
            inpos = false;

        }
    }
}
