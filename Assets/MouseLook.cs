using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y") * -1;
        transform.Rotate(v, h, 0);

        //lock mouse
        if (Input.GetKey(KeyCode.Escape) && true)
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;
    }
}
