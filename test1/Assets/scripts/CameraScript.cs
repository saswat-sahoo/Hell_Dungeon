using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public string gamestate;
    public Transform Target;
    public float offset;
   
    // Update is called once per frame
    void Update()
    {
        gamestate=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().gamestate;
        if(gamestate!="GAMEOVER")
        cameradynamics();
    }

    void cameradynamics()
    {
        Target=GameObject.FindGameObjectWithTag("playermanager").GetComponent<playermanager>().cameraplayer.transform;
        Vector3 CamPosition = new Vector3(Target.position.x, Target.position.y, Target.position.z-offset);
       // CamPosition.z = Target.position.z- offset;
        // Set the camera distance from gameobject and also interpolation speed
        Vector3 cameraMoveDir = (CamPosition - transform.position).normalized;
        float offsetdistance = Vector3.Distance(CamPosition, transform.position);
        float CamSpeed = 2f;

        // Check for overshooting
        if(offsetdistance > 0)
        {
            Vector3 newCameraPosition1 = transform.position + cameraMoveDir * offsetdistance * CamSpeed * Time.deltaTime;
            Vector3 newCameraPosition = new Vector3(newCameraPosition1.x, newCameraPosition1.y, newCameraPosition1.z - offset);

            float offsetDistanceAfterMoving = Vector3.Distance(newCameraPosition, CamPosition);
            if(offsetDistanceAfterMoving > offsetdistance)
            {
                // Camera has overshot the target
                newCameraPosition = CamPosition;
            }
            transform.position = newCameraPosition;
        }
    }
}
