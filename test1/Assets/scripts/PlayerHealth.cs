using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int damage = 10;
    public float firerange;
    public string state;
    private bool takedmg;
    private Collider2D objectCollider;
    private Collider2D objectCollider1;
    private Collider2D objectCollider2;



    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        objectCollider = GameObject.FindGameObjectWithTag("devil").GetComponent<Collider2D>();
        objectCollider1 = GameObject.FindGameObjectWithTag("enemy").GetComponent<Collider2D>();





    }

    void Update()
    {

       
       

       
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            takedmg = true;

            InvokeRepeating("contdamage", 0f, 2f);
        }
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("enemy"))
        {
            TakeDamage(1);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            takedmg = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (state == "enemy")
        {
            if (collider.CompareTag("attack"))
            {
                TakeDamage(damage);
            }
        }
       

        if(state=="player")
        {
           


            if (collider.IsTouching(objectCollider) )
            {

                if (collider.CompareTag("osc"))
                {
                    TakeDamage(5);
                }
                if (collider.CompareTag("fire"))
                {
                    takedmg = true;
                    InvokeRepeating("contdamage", 0f, 1f);
                }
               
            }
            else
            {
                takedmg = false;
            }
        }
        

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (state == "player")
        {
            if (collider.CompareTag("fire"))
            {
                takedmg = false;
            }

            
        }
    }

   
   

    void contdamage()
    {
        if (takedmg)
        {
            TakeDamage(damage);
        }
    }
    private void TakeDamage(int damage)
    {
        if(currentHealth>0)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
    }
}
