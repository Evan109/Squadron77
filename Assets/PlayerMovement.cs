using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject obj;
    private Vector3 playerVelocity;
    private Vector3 playerRotation;
    double dragcoeff = 0.003;
    float sensitivity = 0.1f;
    float speedmul = 0.001f;

    float maininput = 0;
    float vertinput = 0;
    float horizinput = 0;

    float rollinput = 0;
    float yawinput = 0;
    float pitchinput = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerVelocity.x = 0;
        playerVelocity.y = 0;
        playerVelocity.z = 0;
        playerRotation.x = 0;
        playerRotation.y = 0;
        playerRotation.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Thruster Movement: up,down,left,right,fwd,reverse

       

        if (Input.GetKey("s")) maininput += -1;
        if (Input.GetKey("w")) maininput += 1;

        if (Input.GetKey("f")) vertinput += -1;
        if (Input.GetKey("r")) vertinput += 1;

        if (Input.GetKey("q")) horizinput += -1;
        if (Input.GetKey("e")) horizinput += 1;

        if (Input.GetKey("d")) rollinput += -1;
        if (Input.GetKey("a")) rollinput += 1;

        yawinput += Input.GetAxis("Mouse X");

        pitchinput += (Input.GetAxis("Mouse Y")* -1);



        //actually move the thing
        Vector3 movementinput = new Vector3(maininput, vertinput, horizinput);
        obj.transform.position += obj.transform.forward * (movementinput.x * speedmul);
        obj.transform.position += obj.transform.up * (movementinput.y * speedmul);
        obj.transform.position += obj.transform.right * (movementinput.z * speedmul);
        transform.Rotate((pitchinput * sensitivity), (yawinput * sensitivity), (rollinput * speedmul));

        //apply drag
        maininput = (float)(maininput * (1 - dragcoeff));
        vertinput = (float)(vertinput * (1 - dragcoeff));
        horizinput = (float)(horizinput * (1 - dragcoeff));
        pitchinput = (float)(pitchinput * (1 - dragcoeff));
        yawinput = (float)(yawinput * (1 - dragcoeff));
        rollinput = (float)(rollinput * (1 - dragcoeff));

        //zeroout
        if (Math.Abs(maininput) < 0.1) maininput = 0;
        if (Math.Abs(vertinput) < 0.1) vertinput = 0;
        if (Math.Abs(horizinput) < 0.1) horizinput = 0;
        if (Math.Abs(rollinput) < 0.1) rollinput = 0;
        if (Math.Abs(yawinput) < 0.01) yawinput = 0;
        if (Math.Abs(pitchinput) < 0.01) pitchinput = 0;

        //debug
        Debug.Log("Debug :" + maininput + " " + vertinput + " " + horizinput + " " + pitchinput + " " + yawinput + " " + rollinput);


    }     
}

/*
    //Input values into Logistic Functions
    public double TimetoSpeed(double time, int MaxSpeed, int curvestr)
    {
        ///LOGISTIC FUNCTION
        
        /// ___MAX_SPEED___
        ///  1+e^(STEEPNESS(x-0))
        
        if (time > 0.1)
        {
            double output = (MaxSpeed / (1 + (Math.Pow(Math.E, (-(curvestr * (time - 5)))))));
            Debug.Log(" T2S" + time + " " + output);
            return output + 10;
        }
        else
        {
            double output2 = (MaxSpeed / (1 + Math.Pow(Math.E, -(curvestr * (time - 5))))) - MaxSpeed;
            Debug.Log(" T2S" + time + " " + output2);
            return output2 + 10;
        }
    }
        */
