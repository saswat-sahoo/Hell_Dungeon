using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animation_manager : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5f;

    private Animator animator;
    public Transform dir;
    private Rigidbody2D rb2d;
    private string currentAnimaton;
    private bool multikey;
    public string playerstate;
    public string gamestate;
    [SerializeField]
    private float attackDelay = 0.3f;
    private int health;
    private bool Death;
    public Collider2D col1;
   // public Collider2D col2;
    

    //Animation States
    const string PLAYER_IDLE = "Hero_I_R";
    const string PLAYER_IDLE1 = "Hero_I_L";
    const string PLAYER_IDLE2 = "Hero_I_F";
    const string PLAYER_IDLE3 = "Hero_I_B";
    const string PLAYER_RUN = "Hero_W_R";
    const string PLAYER_RUN1 = "Hero_W_L";
    const string PLAYER_RUN2 = "Hero_W_F";
    const string PLAYER_RUN3 = "Hero_W_B";
    const string PLAYER_DEATH = "Hero_D";

    const string PLAYER_ATTACK = "Hero_A_R";
    const string PLAYER_ATTACK1 = "Hero_A_L";
    const string PLAYER_ATTACK2 = "Hero_A_F";
    const string PLAYER_ATTACK3 = "Hero_A_B";
    

    //=====================================================
    // Start is called before the first frame update
    //=====================================================
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col1.enabled = false;
      

    }

    //=====================================================
    // Update is called once per frame
    //=====================================================
    void Update()
    {
        //Checking for inputs
      
        multikey = ((Input.GetKey("w")&& Input.GetKey("a"))||(Input.GetKey("w") && Input.GetKey("s"))||(Input.GetKey("w") && Input.GetKey("d")) || (Input.GetKey("a") && Input.GetKey("d")) || (Input.GetKey("s") && Input.GetKey("d")) || (Input.GetKey("s") && Input.GetKey("a")) || (Input.GetKey("k")&&Input.GetKey("w") ) || (Input.GetKey("k") && Input.GetKey("a")) || (Input.GetKey("k") && Input.GetKey("s")) || (Input.GetKey("k") && Input.GetKey("d")) || (Input.GetKey("k") && Input.GetKey("w") && Input.GetKey("s")) || (Input.GetKey("k") && Input.GetKey("w") && Input.GetKey("a")) || (Input.GetKey("k") && Input.GetKey("w") && Input.GetKey("a")) || (Input.GetKey("k") && Input.GetKey("a") && Input.GetKey("s")) || (Input.GetKey("k") && Input.GetKey("d") && Input.GetKey("s")) || (Input.GetKey("k") && Input.GetKey("a") && Input.GetKey("d")) || (Input.GetKey("k") && Input.GetKey("w") && Input.GetKey("s") && Input.GetKey("a") && Input.GetKey("d")));




        //=====================================================
        // Physics based time step loop
        //=====================================================

        playerstate = GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().playerstate;
        gamestate = GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate;
        health = GetComponent<PlayerHealth>().currentHealth;
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate = "GAMEOVER";
            death();
            Death = true;

            Destroy(this.gameObject, 2f);
        }


        //------------------------------------------

        //Check update movement based on input
        Vector2 vel = new Vector2(0, 0);
        if (!multikey && !Death)
        {
            if (Input.GetKey("d"))
            {
                vel.x = walkSpeed;
                dir.transform.rotation = Quaternion.Euler(0, 0, -90f);
                ChangeAnimationState(PLAYER_RUN);
            }
            else if (Input.GetKey("a"))
            {
                vel.x = -walkSpeed;
                dir.transform.rotation = Quaternion.Euler(0, 0, 90f);
                ChangeAnimationState(PLAYER_RUN1);
            }
            else
            {
                vel.x = 0;


            }
            if (Input.GetKey("s"))
            {
                vel.y = -walkSpeed;
                dir.transform.rotation = Quaternion.Euler(0, 0, 180f);
                ChangeAnimationState(PLAYER_RUN2);

            }
            else if (Input.GetKey("w"))
            {
                vel.y = walkSpeed;

                ChangeAnimationState(PLAYER_RUN3);
                dir.transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            else
            {
                vel.y = 0;

            }

            if (Input.GetKeyUp("w"))
            {
                ChangeAnimationState(PLAYER_IDLE3);
                dir.transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            else if (Input.GetKeyUp("s"))
            {
                ChangeAnimationState(PLAYER_IDLE2);
                dir.transform.rotation = Quaternion.Euler(0, 0, 180f);
            }
            else if (Input.GetKeyUp("a"))
            {
                ChangeAnimationState(PLAYER_IDLE1);
                dir.transform.rotation = Quaternion.Euler(0, 0, 90f);
            }
            else if (Input.GetKeyUp("d"))
            {
                ChangeAnimationState(PLAYER_IDLE);

                dir.transform.rotation = Quaternion.Euler(0, 0, -90f);
            }
        }

        if(multikey && !Death)
        {
            if(Input.GetKey("w") && Input.GetKey("a"))
            {
                vel.y = walkSpeed;
                vel.x = -walkSpeed;
                ChangeAnimationState(PLAYER_RUN3);
                dir.transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            if (Input.GetKey("w") && Input.GetKey("d"))
            {
                vel.y = walkSpeed;
                vel.x = walkSpeed;
                ChangeAnimationState(PLAYER_RUN3);
                dir.transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            if (Input.GetKey("w") && Input.GetKey("s"))
            {
                vel.y = 0;
               
                ChangeAnimationState(PLAYER_RUN3);
                dir.transform.rotation = Quaternion.Euler(0, 0, 0f);
            }
            if (Input.GetKey("s") && Input.GetKey("a"))
            {
                vel.y =-walkSpeed;
                vel.x = -walkSpeed;
                ChangeAnimationState(PLAYER_RUN2);
                dir.transform.rotation = Quaternion.Euler(0, 0, 180f);
            }
            if (Input.GetKey("d") && Input.GetKey("a"))
            {

                vel.x = 0;
                ChangeAnimationState(PLAYER_RUN);
                dir.transform.rotation = Quaternion.Euler(0, 0, -90f);

            }
            if (Input.GetKey("s") && Input.GetKey("d"))
            {
                vel.y = -walkSpeed;
                vel.x = walkSpeed;
                ChangeAnimationState(PLAYER_RUN2);
                dir.transform.rotation = Quaternion.Euler(0, 0, 180f);
            }
           


        }
       
        if(Input.GetKey("k") && !Death)
        {
            if(dir.transform.rotation==Quaternion.Euler(0,0,0))
            {
                ChangeAnimationState(PLAYER_ATTACK3);
                col1.enabled = true;
            }

            if(dir.transform.rotation == Quaternion.Euler(0, 0, 180f))
            {
                ChangeAnimationState(PLAYER_ATTACK2);
                col1.enabled = true;
            }
            if (dir.transform.rotation == Quaternion.Euler(0, 0, 90f))
            {
                ChangeAnimationState(PLAYER_ATTACK1);
                col1.enabled = true;
            }
            if (dir.transform.rotation == Quaternion.Euler(0, 0, -90f))
            {
                ChangeAnimationState(PLAYER_ATTACK);
                col1.enabled = true;
            }
        }
        if (!multikey && !Death)
        {


            if (Input.GetKeyUp("k"))
            {
                if (dir.transform.rotation == Quaternion.Euler(0, 0, 0))
                {
                    ChangeAnimationState(PLAYER_IDLE3);
                }

                if (dir.transform.rotation == Quaternion.Euler(0, 0, 180f))
                {
                    ChangeAnimationState(PLAYER_IDLE2);
                }
                if (dir.transform.rotation == Quaternion.Euler(0, 0, 90f))
                {
                    ChangeAnimationState(PLAYER_IDLE1);
                }
                if (dir.transform.rotation == Quaternion.Euler(0, 0, -90f))
                {
                    ChangeAnimationState(PLAYER_IDLE);
                }

               

                col1.enabled = false;
            }
        }
       

      

        //------------------------------------------

       
        rb2d.velocity = vel;


        //attack
       

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("key"))
        {

            Destroy(collider.gameObject);
            GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate = "LEVELCOMPLETE";
            if (SceneManager.GetActiveScene().buildIndex + 1 != 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }

        }
    }

    void death()
    {
        Invoke("ondeathscene", 2f);
        ChangeAnimationState(PLAYER_DEATH);
        
    }
    void ondeathscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //=====================================================
    // mini animation manager
    //=====================================================
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }





}