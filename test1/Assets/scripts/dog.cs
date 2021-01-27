using System;
using UnityEngine;

public class dog : MonoBehaviour
{
    int health;
    string gamestate;
    private Animator anim;
    public float move = 10f;
    private Rigidbody2D pl;
    private Vector3 movedir;
    public string playerstate;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        pl = GetComponent<Rigidbody2D>();

    }
    
    private void FixedUpdate()
    {
        playerstate=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().playerstate;
        gamestate=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate;
        health=GetComponent<PlayerHealth>().currentHealth;
        if(health<=0)
        {
            GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate="GAMEOVER";
            death();           
            Destroy(this.gameObject,2f);
            
            
        }
        if(gamestate=="playing")
        {
            if(playerstate=="DOG")
            {
                animation_motion();
                pl.velocity = movedir * move;
            }
            else if(playerstate=="DEVIL")
            {
                pl.velocity=new Vector2(0f,0f);
                anim.SetBool("walkf", false);
                anim.SetBool("walkl", false); 
                anim.SetBool("walkr", false);
                anim.SetBool("walkb", false);
            }
        }

    }
    void death()
    {
        pl.velocity=new Vector2(0f,0f);
        anim.SetBool("walkf", false); anim.SetBool("walkl", false); anim.SetBool("walkr", false); anim.SetBool("walkb", false);
        anim.SetTrigger("dead");
        
    }
    private void animation_motion()
    {

        float moveX = 0f, moveY = 0f;
        if (Input.GetKey("w"))
        {
            anim.SetBool("walkf", false); anim.SetBool("walkl", false); anim.SetBool("walkr", false);
            anim.SetBool("walkb", true);
            moveY = 1f;
        }
        else if (Input.GetKey("s"))
        {
            anim.SetBool("walkl", false); anim.SetBool("walkr", false); anim.SetBool("walkb", false);
            anim.SetBool("walkf", true);
            moveY = -1f;
        }
        else if (Input.GetKey("d"))
        {
            anim.SetBool("walkf", false); anim.SetBool("walkl", false); anim.SetBool("walkb", false);
            anim.SetBool("walkr", true);
            moveX = 1f;
        }
        else if (Input.GetKey("a"))
        {
            anim.SetBool("walkf", false); anim.SetBool("walkr", false); anim.SetBool("walkb", false);
            anim.SetBool("walkl", true);
            moveX = -1f;
        }
        else
        {
            anim.SetBool("walkf", false); anim.SetBool("walkl", false); anim.SetBool("walkr", false); anim.SetBool("walkb", false);
        }
        movedir = new Vector3(moveX, moveY).normalized;
    }
}
