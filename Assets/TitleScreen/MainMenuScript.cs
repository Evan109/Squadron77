using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //position references for movement
    public Vector3 currentpos = new Vector3(40, 16, -150);
    public Vector3 targetpos2 = new Vector3(25, 0, 150);
    //position references for rotation
    public Quaternion currentlookdirection = Quaternion.Euler(0, -10, 0);
    public Quaternion lookdirection2 = Quaternion.Euler(0, 0, 0);
    //speed values for movement/rotation
    public int speed = 30;
    public int lookspeed = 3;
    //hyperspaceparticle clone
    public GameObject clone;
    Boolean spawningParticles = true;


    public GameObject mainCamera;
    public GameObject themenu;
    public Boolean camchanging = true;

    public void PlayButton()
    {

        Debug.Log("Play Button pressed");

        themenu.SetActive(false);
        MovetoPos(targetpos2, 5);
        camchanging = true;
        //RotatetoPos(lookdirection2, 1);
        //give camera time to move, wait 5ish seconds then turn off particles
        //waits a bit more and switches scene
        Invoke("disableparticles", 5);
        Invoke("playnextscene", 8);



    }
    public void OptionsButton()
    {
        Debug.Log("Options Button pressed");
    }
    public void QuitButton()
    {
        Debug.Log("Quit Button pressed");
        Debug.Log("Quit Command Recieved");
        Application.Quit();


    }

    // Update is called once per frame
    void Update()
    {
        if (camchanging)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, currentpos, speed);
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, currentlookdirection, lookspeed * (float)(0.5 * Time.deltaTime));
        }
        var pos = GameObject.Find("Shkelzen_kernaja_Explorer_ship").transform.position;
        pos.y += 50;
        var rand = new System.Random();
        if(spawningParticles) 
        {
            for (int i = 0; i < 20; i++)
            {
                float xv = (float)(((rand.NextDouble()) - 0.5) * 450);
                float yv = (float)(((rand.NextDouble()) - 0.5) * 450);
                if (!(xv > (-60 + pos.x) && xv < (60 + pos.x) && yv > (-60 + pos.x) && yv < (60 + pos.y)))
                {
                    GameObject spawnedclone = (GameObject)Instantiate(clone, new Vector3(xv, yv, 800), Quaternion.identity);
                    Destroy(spawnedclone, 2.4f);
                }
            }
        }
    } 

    public void MovetoPos(Vector3 vectorto, int desiredspeed)
    {
        currentpos = vectorto;
        speed = desiredspeed;
    }
    public void RotatetoPos(Quaternion vectorto, int desiredspeed)
    {
        currentlookdirection = vectorto;
        lookspeed = desiredspeed;
    }
    public void disableparticles()
    {
        spawningParticles = false;
    }
    public void playnextscene()
    {
        //play next scene
    }
}
