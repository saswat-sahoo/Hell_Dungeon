using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_tracker : MonoBehaviour
{

    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            key.SetActive(true);
        }
    }
}
