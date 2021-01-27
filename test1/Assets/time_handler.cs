using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_handler : MonoBehaviour
{
    private GameObject kill;
    // Start is called before the first frame update
    void Start()
    {
         kill = GameObject.FindGameObjectWithTag("timer");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(kill);
    }
}
