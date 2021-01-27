using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilator : MonoBehaviour
{
    public int initialdirection;//for right 1 for left -1
    public int amplitude;
    public int oscilation_direction;//in x direction 1 or in y direction -1
    public float disp;
    public float delay;
    [Range(0, 10)] [SerializeField] float oscillatingspeed=1f;
    Vector3 offset;
    Vector3 initialposition;
    void Start()
    {
        initialposition = transform.position;
       // InvokeRepeating("update", 0f, delay);
    }

    // Update is called once per frame
    void Update()
    {
        if (disp == 0)
        {
            if (oscilation_direction == 1)
                offset.x = initialdirection * amplitude * Mathf.Abs(Mathf.Sin(Time.time * Mathf.PI / oscillatingspeed));
            if (oscilation_direction == -1)
                offset.y = initialdirection * amplitude * Mathf.Abs(Mathf.Sin(Time.time * Mathf.PI / oscillatingspeed));
            transform.position = offset + initialposition;
        }

        else if (disp == 1)
        {
            if (oscilation_direction == 1)
                offset.x = initialdirection * amplitude * Mathf.Sin(Time.time * Mathf.PI / oscillatingspeed);
            if (oscilation_direction == -1)
                offset.y = initialdirection * amplitude * Mathf.Sin(Time.time * Mathf.PI / oscillatingspeed);
            transform.position = offset + initialposition;
        }
        else
            transform.position = initialposition;

    }
}
