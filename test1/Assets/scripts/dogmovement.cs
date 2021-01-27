using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogmovement : MonoBehaviour
{
    // Start is called before the first frame update Rigidbody2D playerRb;
    Rigidbody2D playerRb;
    public float  moveSpeed = 30f;
    public string playerstate;
 

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        playerstate=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().playerstate;
        if(playerstate=="DOG")
        {
            movement();
        }
        else if(playerstate=="DEVIL")
        {
            playerRb.velocity=new Vector2(0f,0f);
        }
    }
    void movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        playerRb.velocity = new Vector2(hor * moveSpeed, ver * moveSpeed);
    }
}
