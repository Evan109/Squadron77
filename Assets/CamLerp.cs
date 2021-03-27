using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLerp : MonoBehaviour
{

    public GameObject cam;
    public GameObject target;
    public float speed;
    Vector3 newpos;

    // Update is called once per frame
    void Update()
    {
        newpos = Vector3.Lerp(
            new Vector3(    cam.transform.position.x,       cam.transform.position.y,       cam.transform.position.z), 
            new Vector3(    target.transform.position.x ,   target.transform.position.y ,   target.transform.position.z ),
            speed);
        cam.transform.position = newpos;
    }
}
