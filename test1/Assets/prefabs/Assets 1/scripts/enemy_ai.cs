using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
//using UnityEditor.Experimental.GraphView;

public class enemy_ai : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform fire;
  
    public Transform patrol;
   
    public float speed = 200f;
    public float nextWaypointDistance = 0.01f;
    public  Path path;
    int currentWaypoint = 0;
   // bool reachedEndOfPath = false;
    private  Seeker seeker;
    private Rigidbody2D rb;
   // public Rigidbody2D rb1;
    public float AttackRange = 0.2f;
    public float DetectionRange = 3f;
    //private Vector3 v;
    private float offsetx = 0f;
    private float offsety = 0f;
    Animator Enemy_Controller;
    private Vector2 direction;
    private bool isChasing;
    private string currentAnimaton;
    const string PLAYER_DEATH = "Enemy_Death";
    private int health;
  



    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        Enemy_Controller = GetComponent<Animator>();
       // rb1 = GetComponent<Rigidbody2D>();
        // patrol.position = new Vector3(0f, 0f, 0f);
       // patrol.position = v;
        offsetx = transform.position.x;
        offsety = transform.position.y;

        InvokeRepeating("UpdatePath", 0f, 1f);
        InvokeRepeating("update", 0f, 1f);
        InvokeRepeating("updateMovement", 0f, 0.25f);
        InvokeRepeating("fixedUpdate", 0f, 0.05f);
      

    }    
        
        
        
    
    
    void UpdatePath()
    {
        if (target != null && target2 !=null) {
            if (Vector2.Distance(target.position, transform.position) < DetectionRange && Vector2.Distance(target.position, transform.position) > AttackRange )
            {
                if (seeker.IsDone())
                {
                    seeker.StartPath(rb.position, target.position, OnPathComplete);
                }
            }

            else if (Vector2.Distance(target.position, transform.position) <= AttackRange && Vector2.Distance(target.position, transform.position) < DetectionRange )
            {
                rb.velocity = Vector2.zero;

                Enemy_Controller.SetBool("Shoot", true);
               
                Enemy_Controller.SetBool("Walk_Front", false);
                Enemy_Controller.SetBool("Walk_Left", false);
                Enemy_Controller.SetBool("Walk_Back", false);
                Enemy_Controller.SetBool("Walk_Right", false);
            }
            else if (Vector2.Distance(target2.position, transform.position) < DetectionRange && Vector2.Distance(target2.position, transform.position) > AttackRange)
            {
                if (seeker.IsDone())
                {
                    seeker.StartPath(rb.position, target2.position, OnPathComplete);
                }
            }

            else if (Vector2.Distance(target2.position, transform.position) <= AttackRange && Vector2.Distance(target2.position, transform.position) < DetectionRange)
            {
                rb.velocity = Vector2.zero;
                //Enemy_Controller.SetBool("Shoot", true);
            }
            else
            {
                seeker.StartPath(rb.position, patrol.position, OnPathComplete);

            }
        }
        else
        {
            seeker.StartPath(rb.position, patrol.position, OnPathComplete);

        }
        //Debug.Log(patrol.position);
    }

   

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void update()
    {
        patrol.position = new Vector3(offsetx + UnityEngine.Random.Range(-40.0f, 40.0f), offsety + UnityEngine.Random.Range(-40.0f, 40.0f), 0f);
        health = GetComponent<PlayerHealth>().currentHealth;
        if (health <= 0)
        {
            
            death();
          

           
        }
        /*Enemy_Controller.SetBool("Shoot", false);
        //Enemy_Controller.SetBool("Walk_Front", false);
        //Enemy_Controller.SetBool("Walk_Left", false);
        Enemy_Controller.SetBool("Walk_Back", false);
        Enemy_Controller.SetBool("Walk_Right", false);
        Enemy_Controller.SetBool("Walk_Front",true);*/
    }
    void updateMovement()
    {
        if (Vector2.Distance(target2.position, transform.position) <= AttackRange || Vector2.Distance(target.position, transform.position) <= AttackRange)
        {
            Enemy_Controller.SetBool("Shoot", true);
            
            //if (Enemy_Controller.GetBool("Enemy_Shoot_Back",true))
            {
                

            }
        }
        else
        {
            Enemy_Controller.SetBool("Shoot", false);
           
            {
                if (Math.Abs(rb.velocity.y) > Math.Abs(rb.velocity.x))

                {
                    if (rb.velocity.y > 0)
                    {
                        Enemy_Controller.SetBool("Walk_Front", false);
                        Enemy_Controller.SetBool("Walk_Left", false);
                        Enemy_Controller.SetBool("Walk_Back", true);
                        Enemy_Controller.SetBool("Walk_Right", false);
                    }
                    else
                    {
                        Enemy_Controller.SetBool("Walk_Front", true);
                        Enemy_Controller.SetBool("Walk_Left", false);
                        Enemy_Controller.SetBool("Walk_Back", false);
                        Enemy_Controller.SetBool("Walk_Right", false);
                    }
                }

                else
                {
                    if (rb.velocity.x > 0)
                    {
                        Enemy_Controller.SetBool("Walk_Front", false);
                        Enemy_Controller.SetBool("Walk_Left", false);
                        Enemy_Controller.SetBool("Walk_Back", false);
                        Enemy_Controller.SetBool("Walk_Right", true);
                    }
                    else if(rb.velocity.x<0)
                    {
                        Enemy_Controller.SetBool("Walk_Front", false);
                        Enemy_Controller.SetBool("Walk_Left", true);
                        Enemy_Controller.SetBool("Walk_Back", false);
                        Enemy_Controller.SetBool("Walk_Right", false);
                    }
                }
            }
        }
    }
    
    void fixedUpdate()
    {


        if (path == null)
        {

            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
           // reachedEndOfPath = true;
            return;
        }
        else
        {
           // reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        

        rb.velocity=force;
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }


    void death()
    {
       
        ChangeAnimationState(PLAYER_DEATH);
        Destroy(this.gameObject, 0.6f);

    }
    
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        Enemy_Controller.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
