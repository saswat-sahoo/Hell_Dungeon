using UnityEngine;
using System;

using UnityEngine.SceneManagement;

public class devil : MonoBehaviour
{
    int health;
    public Animator anim;
    public float move = 10f;
    public Rigidbody2D pl;
    private Vector3 movedir;
    private SpriteRenderer sprite;
    public string playerstate;
    public string gamestate;
    public Transform dir;
    public Collider2D coll;



    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        pl = GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        coll.enabled = false;

    }
     void FixedUpdate()
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
            if(playerstate=="DEVIL")
            {
                facemouse();
                animation_motion();
                pl.velocity = movedir * move;
            }
            else if(playerstate=="DOG")
            {
                pl.velocity=new Vector2(0f,0f);
                anim.SetBool("ir", false); 
                anim.SetBool("il", false);
                anim.SetBool("ib", false);
                anim.SetBool("hwf", false);
                anim.SetBool("hwb", false); 
                anim.SetBool("hwl", false); 
                anim.SetBool("hwr", false);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("key"))
        {

            Destroy(collider.gameObject);
            GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate = "LEVELCOMPLETE";
            if (SceneManager.GetActiveScene().buildIndex + 1 != 7)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                SceneManager.LoadScene(0);
            }
           
        }
    }

    void death()
    {
        pl.velocity=new Vector2(0f,0f);

        Invoke("ondeathscene", 2f);

        anim.SetBool("hwf", false); anim.SetBool("hwl", false); anim.SetBool("hwr", false); anim.SetBool("hwb", false);
        
        anim.SetTrigger("hd");
    }
   void ondeathscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
  private void animation_motion()
    {

        float moveX = 0f, moveY = 0f;

        if (Input.GetKey("w"))
      {

          anim.SetBool("hwf", false); anim.SetBool("hwl", false); anim.SetBool("hwr", false);
          anim.SetBool("hwb", true);
          moveY = 1f;
           
            dir.transform.rotation = Quaternion.Euler(0, 0, 0f);

            anim.SetBool("ir", false);
            anim.SetBool("ib", false);
            anim.SetBool("il", false);
            anim.SetBool("if", false);

        }
      
      else if (Input.GetKey("s"))
      {

          anim.SetBool("hwl", false); anim.SetBool("hwr", false); anim.SetBool("hwb", false);
          anim.SetBool("hwf", true);
          moveY = -1f;
         
            dir.transform.rotation = Quaternion.Euler(0, 0, 180f);
            anim.SetBool("ir", false);
            anim.SetBool("ib", false);
            anim.SetBool("il", false);
            anim.SetBool("if", false);
        }
      
      else if (Input.GetKey("d"))
      {
          sprite.flipX = false;
          anim.SetBool("hwf", false); anim.SetBool("hwl", false); anim.SetBool("hwb", false);
          anim.SetBool("hwr", true);
          moveX = 1f;
         
            dir.transform.rotation = Quaternion.Euler(0, 0, -90f);
            anim.SetBool("ir", false);
            anim.SetBool("ib", false);
            anim.SetBool("il", false);
            anim.SetBool("if", false);
        }

     

      else if (Input.GetKey("a"))
      {
          sprite.flipX=false;
          anim.SetBool("hwf", false); anim.SetBool("hwr", false); anim.SetBool("hwb", false);
          anim.SetBool("hwl", true);
          moveX = -1f;
        
            dir.transform.rotation = Quaternion.Euler(0, 0, 90f);
            anim.SetBool("ir", false);
            anim.SetBool("ib", false);
            anim.SetBool("il", false);
            anim.SetBool("if", false);
        }
      
    
        else if (pl.velocity != Vector2.zero)
        {
            anim.SetBool("ir", false);
            anim.SetBool("ib", false);
            anim.SetBool("il", false);
            anim.SetBool("if", false);
        }
       else if (Input.GetKey("space"))
        {

           if(Input.GetKey("w")|| Input.GetKey("a")|| Input.GetKey("s")|| Input.GetKey("d"))
            {
                pl.velocity = Vector2.zero;
            }
            anim.SetBool("ha1", true);
            Invoke("attack", 0.4f);
          
         

        }

        else
      {
        

            anim.SetBool("hwf", false);
            anim.SetBool("hwb", false);
            anim.SetBool("hwl", false);
            anim.SetBool("hwr", false);
            anim.SetBool("ha1", false);
            coll.enabled = false;
            if (dir.transform.rotation.z == 0f)
            {
                anim.SetBool("ir", false);
                anim.SetBool("ib", true);
                anim.SetBool("il", false);
                anim.SetBool("if", false);
            }
            else if (dir.transform.rotation == Quaternion.Euler(0, 0, 180f))
            {
                anim.SetBool("ir", false);
                anim.SetBool("ib", false);
                anim.SetBool("il", false);
                anim.SetBool("if", true);
            }
            else if (dir.transform.rotation == Quaternion.Euler(0, 0, -90f))
            {
                anim.SetBool("ir", true);
                anim.SetBool("ib", false);
                anim.SetBool("il", false);
                anim.SetBool("if", false);
            }
            else if (dir.transform.rotation == Quaternion.Euler(0, 0, 90f))
            {
                anim.SetBool("ir", false);
                anim.SetBool("ib", false);
                anim.SetBool("il", true);
                anim.SetBool("if", false);
            }
        }
      movedir = new Vector3(moveX, moveY).normalized;  
  }

    void attack()
    {
        coll.enabled = true;
    }
  void facemouse()
  {
     



    }
}