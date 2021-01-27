using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_tracker : MonoBehaviour
{
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;
    public SpriteRenderer sp3;
    public SpriteRenderer sp4;
   
    public GameObject key;
    private int a,b,c,d;


    // Start is called before the first frame update
    void Start()
    {
        if (sp1 != null)
        {
            a = 0;
        }
        else if (sp1 = null)
        {
            a = 1;
        }
        if (sp2 != null)
        {
            b = 0;
        }
        else if (sp2 = null)
        {
            b = 1;
        }
        if (sp3 != null)
        {
            c = 0;
        }
        else if (sp3 = null)
        {
            c = 1;
        }
        if (sp4 != null)
        {
            d = 0;
        }
        else if (sp4 = null)
        {
            d = 1;
        }

       
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        
            if (sp1 != null)
            {
                if (sp1.enabled == false && a == 0)
                {
                    a++;
                }
                else if (sp1.enabled == true && a != 0)
                {
                    a--;
                }
            }
            else if (sp1 = null)
            {
                a = 1;
            }
            if (sp2 != null)
            {
                if (sp2.enabled == false && b == 0)
                {
                    b++;
                }
                else if (sp2.enabled == true && b != 0)
                {
                    b--;
                }
            }
            else if (sp2 = null)
            {
                b = 1;
            }
            if (sp3 != null)
            {
                if (sp3.enabled == false && c == 0)
                {
                    c++;
                }
                else if (sp3.enabled == true && c != 0)
                {
                    c--;
                }
            }
            else if (sp3 = null)
            {
                c = 1;
            }
            if (sp4 != null)
            {
                if (sp4.enabled == false && d == 0)
                {
                    d++;
                }
                else if (sp4.enabled == true && d != 0)
                {
                    d--;
                }
            }
            else if (sp4 = null)
            {
                d = 1;
            }


            if (a + b + c + d == 4)
            {
                Debug.Log("ok");
                key.SetActive(true);
            }
        else
        {
            key.SetActive(false);
        }

    }
}
