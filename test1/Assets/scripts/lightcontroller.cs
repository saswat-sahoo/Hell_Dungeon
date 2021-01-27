using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcontroller : MonoBehaviour
{
    public GameObject lamp;
    public SpriteRenderer lampsprite;
    // Start is called before the first frame update
    void Start()
    {
        //lamp= GameObject.FindGameObjectWithTag("seeklight");
        //lampsprite=GameObject.FindGameObjectWithTag("seeklightsprite").GetComponent<SpriteRenderer>();
        lampsprite.enabled = false;
        lamp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "devil")
        {
            lamp.SetActive(true);
            lampsprite.enabled = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "devil")
        {
            lamp.SetActive(false);
            lampsprite.enabled = false;
           
        }
    }
}
