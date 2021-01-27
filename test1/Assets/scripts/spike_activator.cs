using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_activator : MonoBehaviour
{
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        spike.SetActive(false);
        InvokeRepeating("spiketrigger", 0f, 1.7f);
        InvokeRepeating("spiketrigger2", 1.8f, 0.7f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spiketrigger()
    {
        spike.SetActive(true);
    }
    void spiketrigger2()
    {
        spike.SetActive(false);
    }

}

