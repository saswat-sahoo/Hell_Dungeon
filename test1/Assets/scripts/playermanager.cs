using UnityEngine.UI;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    #region Singleton
    public static playermanager instance;
    void Awake()
    {
        instance = this;
        
    }
    #endregion
    public string gamestate="playing";
    private Text text1;
    public GameObject cameraplayer;
    private GameObject devilplayer;
    private GameObject dogplayer;
    
    public string playerstate="DEVIL";
    void Start()
    {
        devilplayer=GameObject.FindGameObjectWithTag("devil");
        dogplayer=GameObject.FindGameObjectWithTag("dog");
        cameraplayer=devilplayer;
        
        //dogplayer.GetComponent<dogmovement>().enabled=false;
        
    }

  
    void FixedUpdate()
    {
      if(gamestate=="playing")
        playerswitch();
      else if(gamestate=="GAMEOVER")
      {
         // text1.text="GAME OVER";
      }
      else if (gamestate=="LEVELCOMPLETE")
      {
        //text1.text="LEVEL COMPLETE";
      }

    }

    void playerswitch()
    {
      if (Input.GetKey("q"))
        {
          
            playerstate="DEVIL";
            cameraplayer=devilplayer;
          

        }
       /* if (Input.GetKey("e"))
        {
          
            playerstate="DOG";
            cameraplayer=dogplayer;
          

        }*/
    }
}
