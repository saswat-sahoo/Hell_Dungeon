using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text timerText;
    private float StartTime;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;  
    }
  void Awake()
    {
        GameObject manager= GameObject.FindGameObjectWithTag("timer_manager");
       
        if (manager != null)
        {
            GameObject[] timers = GameObject.FindGameObjectsWithTag("timer");
            if (timers.Length > 1 || SceneManager.GetActiveScene().name == "menu")
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                this.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
      
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - StartTime;
        string hours = ((int)t / 3600).ToString();
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        string miliseconds = ((t - ((int)t ))*100).ToString("f0");
        timerText.text = "Time:" + hours + ":" + minutes + ":" + seconds;
        
    }
}
