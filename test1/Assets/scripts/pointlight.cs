using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointlight : MonoBehaviour
{
    // Start is called before the first frame update
    string gamestate;

    void Start()
    {
        gamestate=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamestate=="GAMEOVER")
        {
            Vector3 pos=GetComponentInParent<Transform>().position;
            transform.parent=null;
            transform.position=pos;
            
        }
    }
}
