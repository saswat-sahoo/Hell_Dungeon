﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait ()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(1);
    }
    
}
